<script>
// console.log(import.meta.env.VITE_SOME_KEY)
import { useNavigationStore } from "@/stores/navigation";
import { storeToRefs } from "pinia";
import { defineComponent } from "vue";
import NavigationDrawerItemsVue from "../components/NavigationDrawerItems.vue";

export default {
  components: {
    NavigationDrawerItemsVue,
  },
  setup() {
    const navigationStore = useNavigationStore();
    navigationStore.addDefaultRoute();
    return { navigationStore };
  },
  data: () => ({}),
  methods: {
    clickBtn: function () {
      this.counterStore.multiply();
    },
  },
  computed: {
    getNavigationItems: function () {
      return this.items;
    },
  },
};
</script>

<template>
  <v-app>
    <v-navigation-drawer app>
      <NavigationDrawerItemsVue></NavigationDrawerItemsVue>
    </v-navigation-drawer>

    <v-app-bar color="white" app> </v-app-bar>

    <!-- Sizes your content based upon application components -->
    <v-main>
      <!-- Provides the application the proper gutter -->
      <v-container fluid>
        <!-- If using vue-router -->
        <router-view></router-view>
      </v-container>
    </v-main>
  </v-app>
</template>

<style scoped>
</style>
