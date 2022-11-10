<script>
// console.log(import.meta.env.VITE_SOME_KEY)
import { useNavigationStore } from "@/stores/navigation";
import { useLoginStore } from "@/stores/login";
import { storeToRefs } from "pinia";
import { defineComponent } from "vue";
import NavigationDrawerItemsVue from "../components/NavigationDrawerItems.vue";

export default {
  components: {
    NavigationDrawerItemsVue,
  },
  setup() {
    const navigationStore = useNavigationStore();
    const loginStore = useLoginStore();
    navigationStore.addDefaultRoute();
    return { navigationStore, loginStore };
  },
  data: () => ({}),
  methods: {
    clickBtn: function () {
      this.counterStore.multiply();
    },
    logout() {
      this.loginStore.logout();
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

    <v-app-bar color="white" app>
      <v-spacer></v-spacer>
      <v-row justify="end">
        <v-menu bottom min-width="200px" rounded offset-y>
          <template v-slot:activator="{ on }">
            <v-btn icon x-large v-on="on">
              <v-avatar color="primary" size="48">
                <span class="white--text text-h5">A</span>
              </v-avatar>
            </v-btn>
          </template>
          <v-card>
            <v-list-item-content class="justify-center">
              <div class="mx-auto text-center">
                <v-avatar color="primary">
                  <span class="white--text text-h5">A</span>
                </v-avatar>
                <h3>Pulse Admin</h3>
                <p class="text-caption mt-1">admin@pulsesoftware.com</p>
                <v-divider class="my-3"></v-divider>
                <v-btn depressed rounded text> Edit Account </v-btn>
                <v-divider class="my-3"></v-divider>
                <v-btn depressed rounded text @click="logout()"> Logout </v-btn>
              </div>
            </v-list-item-content>
          </v-card>
        </v-menu>
      </v-row>
    </v-app-bar>

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
