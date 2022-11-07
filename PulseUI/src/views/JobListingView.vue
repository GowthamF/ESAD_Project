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
    ></v-data-table>
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
            filterable: false,
            value: 'jobName',
          },
          
        ],
        desserts: [ ],
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