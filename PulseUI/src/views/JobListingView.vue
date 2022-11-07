<template>
  <v-card>
    <v-card-title>
      <v-text-field
        v-model="search"
        append-icon="mdi-magnify"
        label="Search"
        single-line
        hide-details
      ></v-text-field>
    </v-card-title>
    <v-data-table
      :headers="headers"
      :items="getJobs"
      :search="search"
      sort-by="jobName"
    >
    <template v-slot:item.status="{ item }">
      <v-chip :color="'primary'">
        {{ item.status }}
      </v-chip>
    </template>
    <template v-slot:item.jobName="{ item }">
      <b>{{item.jobName.toUpperCase()}}</b>
    </template>
    <template v-slot:item.hiringManagers="{ item }">
      <v-row justify="start">
      <div v-for="hiringManager of item.hiringManagers" :key="hiringManager">
        <v-container fluid>
          <v-tooltip top>
          <template v-slot:activator="{ on, attrs }">
            <v-avatar color="primary" size="25">
          <v-icon v-bind="attrs"
                  v-on="on" dark
          >
            mdi-account-circle
          </v-icon>
        </v-avatar>
          </template>
          <span>{{hiringManager}}</span>
        </v-tooltip>
        </v-container>
      </div>
    </v-row>
    </template>
    <template v-slot:item.actions="{ item }">
      <v-icon
        small
        class="mr-2"
        @click="editItem(item)"
      >
        mdi-pencil
      </v-icon>
      <v-icon
        small
        @click="deleteItem(item)"
      >
        mdi-delete
      </v-icon>
    </template>
    <template v-slot:no-data>
      <v-btn
        color="primary"
        @click="initialize"
      >
        Reset
      </v-btn>
    </template>
    </v-data-table>
  </v-card>
</template>

<script>
    import { useJobListingStore } from '@/stores/job_listing'
  export default {
    setup() {
        const jobListingStore = useJobListingStore()
        
        return { jobListingStore }
    },
    data () {
      return {
        search: '',
        headers: [
          {
            text: 'Job Name',
            align: 'start',
            value: 'jobName',
          },
          {
            text: 'Posting Date',
            align: 'start',
            filterable: false,
            value: 'postingDate',
          },
          {
            text: 'Candidates',
            align: 'start',
            filterable: false,
            value: 'candidates',
          },
          {
            text: 'Hiring Managers',
            align: 'start',
            filterable: false,
            value: 'hiringManagers',
          },
          {
            text: 'Status',
            align: 'start',
            filterable: false,
            value: 'status',
          },
          { text: '', value: 'actions', sortable: false },
        ],
      }
    },
    mounted(){
        this.jobListingStore.getJobs();
    },
    computed:{
        getJobs(){
            return this.jobListingStore.jobs;
        }
    }
  }
</script>

<style>

</style>