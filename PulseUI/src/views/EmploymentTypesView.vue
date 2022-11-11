<template>
  <v-data-table
    :headers="headers"
    :items="getEmploymentTypes"
    sort-by="calories"
    class="elevation-1"
  >
    <template v-slot:top>
      <v-toolbar flat>
        <v-toolbar-title>Employment Types</v-toolbar-title>
        <v-divider class="mx-4" inset vertical></v-divider>
        <v-spacer></v-spacer>
        <v-dialog v-model="dialog" max-width="500px" persistent>
          <template v-slot:activator="{ on, attrs }">
            <v-btn color="primary" dark class="mb-2" v-bind="attrs" v-on="on">
              Add Employment Type
            </v-btn>
          </template>
          <TypesCreationVue
            :modalTitle="'Employment Type'"
            @save-type="saveEmploymentType"
            @close-dialog="closeModel"
          ></TypesCreationVue>
        </v-dialog>
      </v-toolbar>
    </template>
    <template v-slot:[`item.actions`]="{ item }">
      <v-tooltip top>
        <template v-slot:activator="{ on, attrs }">
          <v-btn
            icon
            small
            @click="deleteEmploymentType(item.employmentTypeId)"
            v-on="on"
            v-bind="attrs"
          >
            <v-icon dark small> mdi-delete </v-icon>
          </v-btn>
        </template>
        <span>Delete Employment Type</span>
      </v-tooltip>
    </template>
  </v-data-table>
</template>

<script>
import TypesCreationVue from "../components/TypesCreation.vue";
import { useEmploymentTypesStore } from "@/stores/employment_types.js";

export default {
  setup() {
    const employmentTypesStore = useEmploymentTypesStore();

    return { employmentTypesStore };
  },
  components: {
    TypesCreationVue,
  },
  data: () => ({
    dialog: false,
    headers: [
      {
        text: "Employment Type Name",
        align: "center",
        value: "employmentTypeName",
      },
      { text: "", value: "actions", sortable: false },
    ],
  }),
  methods: {
    saveEmploymentType(employmentTypeName) {
      this.employmentTypesStore.createEmploymentType(employmentTypeName);
      this.dialog = false;
    },
    closeModel() {
      this.dialog = false;
    },
    deleteEmploymentType(id) {
      this.employmentTypesStore.deleteEmploymentType(id);
    },
  },
  computed: {
    getEmploymentTypes() {
      return this.employmentTypesStore.employmentTypes;
    },
  },
  mounted() {
    this.employmentTypesStore.getEmploymentTypes();
  },
};
</script>

<style>
</style>