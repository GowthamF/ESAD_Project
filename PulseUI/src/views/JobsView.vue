<template>
  <div v-if="jobs.length">
    <Job :jobs="jobs"></Job>
  </div>
</template>

<script>
import Job from "../components/Job.vue";
import { useJobListingStore } from "@/stores/job_listing";

export default {
  components: {
    Job,
  },
  setup() {
    const jobListingStore = useJobListingStore();

    return { jobListingStore };
  },
  data: () => ({}),
  props: {
    isPublic: {
      type: Boolean,
      required: true,
    },
  },
  mounted() {
    if (this.isPublic) {
      this.jobListingStore.getPublicJobs();
    } else {
      this.jobListingStore.getInternalJobs();
    }
  },
  computed: {
    jobs() {
      if (this.isPublic) {
        return this.jobListingStore.publicJobs;
      }
      return this.jobListingStore.internalJobs;
    },
  },
};
</script>

<style>
</style>