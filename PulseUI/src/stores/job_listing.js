import { defineStore } from "pinia";
import axios from "axios";

export const useJobListingStore = defineStore("jobListingStore", {
  state: () => ({
    jobServiceUrl: import.meta.env.VITE_JOB_SERVICE_URL,
    jobs: [],
    dialog: false,
    isArchivedJobs: false,
    publicJobs: [],
    internalJobs: [],
  }),
  actions: {
    async getJobs() {
      try {
        var response = await axios.get(
          `${this.$state.jobServiceUrl}/RCMJobs/GetJobs/${this.$state.isArchivedJobs}`
        );
        this.$state.jobs = response.data;
      } catch (error) {
        return [];
      }
    },
    async editJob(job) {
      try {
        var response = await axios.put(
          `${this.$state.jobServiceUrl}/RCMJobs/UpdateJob`,
          job
        );

        this.getJobs();
      } catch (error) {}
    },
    async addJob(job) {
      try {
        var response = await axios.post(
          `${this.$state.jobServiceUrl}/RCMJobs/CreateJob`,
          job
        );
        this.getJobs();
      } catch (error) {}
    },
    async deleteJob(jobId) {
      try {
        var response = await axios.delete(
          `${this.$state.jobServiceUrl}/RCMJobs/DeleteJob/${jobId}`
        );
        this.getJobs();
      } catch (error) {}
    },
    async deleteJob(jobId) {
      try {
        var response = await axios.delete(
          `${this.$state.jobServiceUrl}/RCMJobs/DeleteJob/${jobId}`
        );
        this.getJobs();
      } catch (error) {}
    },
    async getPublicJobs() {
      try {
        var response = await axios.get(
          `${this.$state.jobServiceUrl}/JobListing/GetPublicJobs`
        );
        this.$state.publicJobs = response.data;
      } catch (error) {
        return [];
      }
    },
    async getInternalJobs() {
      try {
        var response = await axios.get(
          `${this.$state.jobServiceUrl}/JobListing/GetInternalJobs`
        );
        this.$state.internalJobs = response.data;
      } catch (error) {
        return [];
      }
    },
  },
});
