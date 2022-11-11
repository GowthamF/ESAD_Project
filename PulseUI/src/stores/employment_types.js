import { defineStore } from "pinia";
import axios from "axios";

// main is the name of the store. It is unique across your application
// and will appear in devtools
export const useEmploymentTypesStore = defineStore("employmentTypesStore", {
  state: () => ({
    baseUrl: import.meta.env.VITE_JOB_SERVICE_URL,
    employmentTypes: [],
    employmentTypesDropDown: [],
  }),
  actions: {
    async getEmploymentTypes() {
      try {
        var response = await axios.get(
          `${this.$state.baseUrl}/RCMEmploymentType/GetEmploymentTypes`
        );
        this.$state.employmentTypes = response.data;

        this.$state.employmentTypesDropDown = this.$state.employmentTypes.map(
          (x) => {
            return {
              ["text"]: x.employmentTypeName,
              ["value"]: x.employmentTypeId,
            };
          }
        );
      } catch (error) {
        return [];
      }
    },
    async createEmploymentType(employmentType) {
      try {
        var response = await axios.post(
          `${this.$state.baseUrl}/RCMEmploymentType/CreateEmploymentType`,
          employmentType,
          {
            headers: {
              ["accept"]: "text/plain",
              ["Content-Type"]: "application/json",
            },
          }
        );
        this.getEmploymentTypes();
      } catch (error) {}
    },
    async deleteEmploymentType(employmentTypeId) {
      try {
        var response = await axios.delete(
          `${this.$state.baseUrl}/RCMEmploymentType/DeleteEmploymentType/${employmentTypeId}`
        );
        this.getEmploymentTypes();
      } catch (error) {}
    },
  },
});
