<template>
  <v-app>
    <v-app-bar color="white" app>
      <h1>{{ isPublic ? "Public Jobs" : "Internal Jobs" }}</h1>
    </v-app-bar>
    <v-main>
      <v-container fluid>
        <router-view></router-view>
      </v-container>
    </v-main>
  </v-app>
</template>
<script>
export default {
  data() {
    return {};
  },
  props: {
    isPublic: {
      type: Boolean,
      required: true,
    },
  },
};
</script>
  
  <style>
</style>