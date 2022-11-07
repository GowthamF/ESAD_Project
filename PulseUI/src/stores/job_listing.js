import { defineStore } from "pinia";
import axios from "axios";

export const useJobListingStore = defineStore("jobListingStore", {
  state: () => ({
    jobServiceUrl: import.meta.env.VITE_JOB_SERVICE_URL,
    jobs: [],
  }),
  actions: {
    async getJobs() {
      try {
        var response = await axios.get(
          `${this.$state.jobServiceUrl}/RCMJobs/GetJobs`
        );
        this.$state.jobs = response.data;
      } catch (error) {}
    },
  },
});
