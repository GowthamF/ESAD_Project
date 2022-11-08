<template>
  <v-card>
    <v-card-title>
      <span class="text-h5">{{ editJob ? "Edit Job" : "Add Job" }}</span>
    </v-card-title>
    <v-card-text>
      <v-container fluid>
        <v-col>
          <v-form ref="form" v-model="valid" lazy-validation>
            <v-text-field
              outlined
              v-model="jobName"
              :rules="jobNameRule"
              label="Job name"
              required
            ></v-text-field>
            <v-textarea
              outlined
              v-model="jobDescription"
              clearable
              :rules="jobDescriptionRule"
              auto-grow
              clear-icon="mdi-close-circle"
              label="Job Description"
            ></v-textarea>
            <v-row class="d-flex">
              <v-col>
                <v-select
                  :items="jobViews"
                  outlined
                  v-model="selectedView"
                  label="Employment Type"
                ></v-select>
              </v-col>
              <v-col>
                <v-select
                  :items="jobViews"
                  outlined
                  v-model="selectedView"
                  label="Compensation Type"
                ></v-select>
              </v-col>
            </v-row>
            <v-btn outlined color="primary" @click="isPublic = !isPublic">
              {{ !isPublic ? "List as Public Job" : "Unlist from Public Jobs" }}
            </v-btn>
          </v-form>
        </v-col>
      </v-container>
    </v-card-text>
    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn color="blue darken-1" text @click="close()"> Close </v-btn>
      <v-btn color="blue darken-1" text @click="save()"> Save </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
export default {
  methods: {
    close() {
      this.$refs.form.resetValidation();
      this.$emit("close-dialog");
    },
    save() {
      this.$emit("save-job", {
        id: this.jobId,
        jobName: this.jobName,
        jobDescription: this.jobDescription,
        isPublic: this.isPublic,
        isEdit: this.editJob ? true : false,
      });
    },
  },
  data: () => ({
    valid: false,
    jobName: "",
    jobId: 0,
    jobDescription: "",
    isPublic: false,
    jobNameRule: [(v) => !!v || "Job Name is required"],
    jobDescriptionRule: [
      (v) => !!v || "Job Description is required",
      (v) => (v || "").length <= 50 || "Max 50 characters",
    ],
  }),
  props: {
    editJob: {
      type: Object,
      default: null,
    },
  },
  mounted() {
    this.jobName = this.editJob ? this.editJob.jobName : "";
    this.jobDescription = this.editJob ? this.editJob.jobDescription : "";
    this.isPublic = this.editJob ? this.editJob.isPublic : false;
    this.jobId = this.editJob ? this.editJob.id : 0;
  },
};
</script>

<style>
</style>