<template>
  <v-card>
    <v-container fluid>
      <v-row no-gutters>
        <v-col class="d-flex" cols="12" sm="6" md="2">
          <v-select
            :items="jobViews"
            solo
            v-model="selectedView"
            @change="changeView(selectedView)"
          ></v-select>
        </v-col>
        <v-spacer></v-spacer>
        <v-spacer></v-spacer>
        <div>
          <v-row align-content="end" justify="end">
            <v-container fluid>
              <v-btn
                text
                class="mb-2"
                color="primary"
                @click="openPublicJobs()"
              >
                Public Jobs
              </v-btn>
              <v-btn
                text
                class="mb-2"
                color="primary"
                @click="openInternalJobs()"
              >
                Internal Jobs
              </v-btn>
            </v-container>
          </v-row>
        </div>
      </v-row>
    </v-container>
    <v-spacer></v-spacer>
    <v-dialog
      v-if="jobListingStore.dialog"
      v-model="jobListingStore.dialog"
      persistent
      max-width="50%"
      eager
      attach
    >
      <JobCreation
        @close-dialog="closeModel()"
        @save-job="saveJob"
        :edit-job="selectedJob"
        :employment-types="getEmploymentTypes"
      ></JobCreation>
    </v-dialog>
    <v-card-title>
      <v-text-field
        v-model="search"
        append-icon="mdi-magnify"
        label="Search"
        single-line
        hide-details
      ></v-text-field>
      <v-spacer></v-spacer>
      <v-btn text color="primary" dark class="mb-2" @click="editJob()">
        Add Job
      </v-btn>
    </v-card-title>
    <v-data-table
      :headers="headers"
      :items="getJobs"
      :search="search"
      sort-by="jobName"
    >
      <template v-slot:[`item.status`]="{ item }">
        <v-chip :color="'primary'" outlined>
          {{ item.status }}
        </v-chip>
      </template>
      <template v-slot:[`item.jobName`]="{ item }">
        <b>{{ item.jobName.toUpperCase() }}</b>
      </template>
      <template v-slot:[`item.hiringManagers`]="{ item }">
        <v-row justify="start">
          <div
            v-for="hiringManager of item.hiringManagers"
            :key="hiringManager"
          >
            <v-container fluid>
              <v-tooltip top>
                <template v-slot:activator="{ on, attrs }">
                  <v-avatar color="primary" size="25">
                    <v-icon v-bind="attrs" v-on="on" dark>
                      mdi-account-circle
                    </v-icon>
                  </v-avatar>
                </template>
                <span>{{ hiringManager }}</span>
              </v-tooltip>
            </v-container>
          </div>
        </v-row>
      </template>
      <template v-slot:[`item.actions`]="{ item }">
        <v-tooltip top>
          <template v-slot:activator="{ on, attrs }">
            <v-btn icon small @click="editJob(item)" v-on="on" v-bind="attrs">
              <v-icon dark small> mdi-pencil </v-icon>
            </v-btn>
          </template>
          <span>Edit Job</span>
        </v-tooltip>

        <v-tooltip top>
          <template v-slot:activator="{ on, attrs }">
            <v-btn
              icon
              small
              @click="deleteJob(item.id)"
              v-on="on"
              v-bind="attrs"
            >
              <v-icon dark small> mdi-delete </v-icon>
            </v-btn>
          </template>
          <span>Delete Job</span>
        </v-tooltip>

        <v-tooltip top v-if="!jobListingStore.isArchivedJobs">
          <template v-slot:activator="{ on, attrs }">
            <v-btn
              icon
              small
              @click="archiveJob(item)"
              v-on="on"
              v-bind="attrs"
            >
              <v-icon dark small> mdi-archive </v-icon>
            </v-btn>
          </template>
          <span>Archive Job</span>
        </v-tooltip>

        <v-tooltip top v-if="jobListingStore.isArchivedJobs">
          <template v-slot:activator="{ on, attrs }">
            <v-btn
              icon
              small
              @click="unArchiveJob(item)"
              v-on="on"
              v-bind="attrs"
            >
              <v-icon dark small> mdi-archive-remove </v-icon>
            </v-btn>
          </template>
          <span>Unarchive Job</span>
        </v-tooltip>
      </template>
      <template v-slot:no-data>
        <!-- <v-progress-circular
      indeterminate
      color="primary"
    ></v-progress-circular> -->
      </template>
    </v-data-table>
  </v-card>
</template>

<script>
import { useJobListingStore } from "@/stores/job_listing";
import { useEmploymentTypesStore } from "@/stores/employment_types";
import JobCreation from "../components/JobCreation.vue";
export default {
  components: {
    JobCreation,
  },
  setup() {
    const jobListingStore = useJobListingStore();
    const employmentTypesStore = useEmploymentTypesStore();

    return { jobListingStore, employmentTypesStore };
  },
  data() {
    return {
      search: "",
      headers: [
        {
          text: "Job Name",
          align: "start",
          value: "jobName",
        },
        {
          text: "Closing Date",
          align: "start",
          filterable: false,
          value: "closingDate",
        },
        {
          text: "Posting Date",
          align: "start",
          filterable: false,
          value: "postingDate",
        },
        {
          text: "Candidates",
          align: "start",
          filterable: false,
          value: "candidates",
        },
        {
          text: "Hiring Managers",
          align: "start",
          filterable: false,
          value: "hiringManagers",
        },
        {
          text: "Status",
          align: "start",
          filterable: false,
          value: "status",
        },
        { text: "", value: "actions", sortable: false },
      ],
      isEdit: false,
      selectedJob: null,
      selectedView: "JobListings",
      jobViews: [
        {
          text: "Job Listings",
          value: "JobListings",
        },
        {
          text: "Archived Jobs",
          value: "ArchivedJobs",
        },
      ],
    };
  },
  mounted() {
    this.jobListingStore.getJobs();
    this.employmentTypesStore.getEmploymentTypes();
  },
  computed: {
    getJobs() {
      return this.jobListingStore.jobs;
    },
    getEmploymentTypes() {
      return this.employmentTypesStore.employmentTypesDropDown;
    },
  },
  methods: {
    editJob(job) {
      if (job) {
        this.selectedJob = job;
        this.isEdit = true;
      }

      this.jobListingStore.dialog = true;
    },
    deleteJob(jobId) {
      this.jobListingStore.deleteJob(jobId);
    },
    closeModel() {
      this.jobListingStore.dialog = false;
      this.isEdit = false;
      this.selectedJob = null;
    },
    saveJob(job) {
      if (this.isEdit) {
        this.jobListingStore.editJob(job);
        this.closeModel();
      } else {
        this.jobListingStore.addJob(job);
        this.closeModel();
      }
    },
    archiveJob(job) {
      job.isArchived = true;
      this.jobListingStore.editJob(job);
    },
    unArchiveJob(job) {
      job.isArchived = false;
      this.jobListingStore.editJob(job);
    },
    changeView(selectedView) {
      this.jobListingStore.isArchivedJobs = selectedView === "ArchivedJobs";
      this.jobListingStore.getJobs();
    },
    openPublicJobs() {
      window.open(`${window.location.origin}/public-jobs`);
    },
    openInternalJobs() {
      window.open(`${window.location.origin}/internal-jobs`);
    },
  },
};
</script>

<style scoped>
.v-btn {
  pointer-events: all;
}
</style>