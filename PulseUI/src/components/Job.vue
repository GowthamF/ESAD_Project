<template>
  <v-card elevation="2" outlined shaped>
    <v-list>
      <template v-for="(job, index) in jobs">
        <v-container fluid :key="index">
          <v-row>
            <v-col>
              <v-list-item>
                <v-list-item-content>
                  <v-list-item-title
                    >Job Title : {{ job.jobTitle }}</v-list-item-title
                  >
                  <v-list-item-subtitle
                    >Job Description :
                    {{ job.jobDescription }}</v-list-item-subtitle
                  >
                  <v-list-item-subtitle
                    >Closing Date : {{ job.closingDate }}</v-list-item-subtitle
                  >
                  <v-spacer></v-spacer>
                  <v-divider inset></v-divider>
                </v-list-item-content>
                <v-list-item-action>
                  <v-btn outlined color="primary" @click="applyJob(job.jobId)"
                    >Apply Now</v-btn
                  >
                </v-list-item-action>
              </v-list-item>
            </v-col>
          </v-row>
        </v-container>
      </template>
    </v-list>
  </v-card>
</template>

<script>
export default {
  props: {
    jobs: {
      type: Array,
      required: true,
    },
  },
  methods: {
    applyJob(jobId) {
      this.$emit("apply-job", jobId);
    },
  },
};
</script>

<style>
</style>