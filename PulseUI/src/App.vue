<script>
// console.log(import.meta.env.VITE_SOME_KEY)
export default {
    data: () => ({
      drawer: false,
      group: null,
    }),
    components: {
      
    }
  }
</script>

<template>
  <v-app>
  <v-navigation-drawer v-model="drawer"
      absolute
      temporary>
    <!-- -->
  </v-navigation-drawer>

  <v-app-bar app>
    <v-app-bar-nav-icon @click="drawer = true"></v-app-bar-nav-icon>
  </v-app-bar>

  <!-- Sizes your content based upon application components -->
  <v-main>

    <!-- Provides the application the proper gutter -->
    <v-container fluid>
      
      <!-- If using vue-router -->
      <router-view></router-view>
    </v-container>
  </v-main>

  <v-footer app>
    <!-- -->
  </v-footer>
</v-app>
</template>

<style scoped>

</style>
