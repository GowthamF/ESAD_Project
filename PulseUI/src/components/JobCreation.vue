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
            <v-row class="d-flex mb-6">
              <v-col>
                <v-select
                  v-model="selectedEmploymentType"
                  :items="employmentTypes"
                  outlined
                  label="Employment Type"
                ></v-select>
              </v-col>

              <v-col>
                <v-dialog
                  ref="dialog"
                  v-model="modal"
                  :return-value.sync="selectedDate"
                  persistent
                  width="290px"
                >
                  <template v-slot:activator="{ on, attrs }">
                    <v-text-field
                      v-model="selectedDate"
                      label="Closing Date"
                      append-icon="mdi-calendar"
                      readonly
                      outlined
                      v-bind="attrs"
                      v-on="on"
                      :rules="jobClosingDateRule"
                    ></v-text-field>
                  </template>
                  <v-date-picker
                    v-model="initialDate"
                    scrollable
                    color="primary"
                  >
                    <v-spacer></v-spacer>
                    <v-btn text color="primary" @click="modal = false">
                      Cancel
                    </v-btn>
                    <v-btn
                      text
                      color="primary"
                      @click="$refs.dialog.save(initialDate)"
                    >
                      OK
                    </v-btn>
                  </v-date-picker>
                </v-dialog>
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
      var isValid = this.$refs.form.validate();
      if (isValid) {
        this.$emit("save-job", {
          id: this.jobId,
          jobName: this.jobName,
          jobDescription: this.jobDescription,
          isPublic: this.isPublic,
          isEdit: this.editJob ? true : false,
          closingDate: this.selectedDate,
          employmentTypeId: this.selectedEmploymentType,
        });
      }
    },
  },
  data: () => ({
    selectedEmploymentType: null,
    valid: false,
    selectedDate: null,
    initialDate: new Date(Date.now() - new Date().getTimezoneOffset() * 60000)
      .toISOString()
      .substring(0, 10),
    modal: false,
    jobName: "",
    jobId: 0,
    jobDescription: "",
    isPublic: false,
    jobNameRule: [(v) => !!v || "Job Name is required"],
    jobDescriptionRule: [
      (v) => !!v || "Job Description is required",
      (v) => (v || "").length <= 50 || "Max 50 characters",
    ],
    jobClosingDateRule: [(v) => !!v || "Job Closing Date is required"],
  }),
  props: {
    editJob: {
      type: Object,
      default: null,
    },
    employmentTypes: {
      type: Array,
      default: [],
    },
  },
  mounted() {
    this.jobName = this.editJob ? this.editJob.jobName : "";
    this.jobDescription = this.editJob ? this.editJob.jobDescription : "";
    this.isPublic = this.editJob ? this.editJob.isPublic : false;
    this.jobId = this.editJob ? this.editJob.id : 0;
    this.selectedDate = this.editJob ? this.editJob.closingDate : null;
    this.selectedEmploymentType = this.editJob
      ? this.editJob.employmentTypeId
      : null;
  },
};
</script>

<style>
</style>