<template>
  <div>
    <v-list-item>
      <v-list-item-content>
        <v-list-item-title class="text-h6"> Pulse </v-list-item-title>
      </v-list-item-content>
    </v-list-item>

    <v-list dense nav v-for="item in getNavigationItems" :key="item.title">
      <v-list-item
        link
        @click="navigate(item.routeName, item.title)"
        v-if="!item.group"
      >
        <v-list-item-icon>
          <v-icon>{{ item.icon }}</v-icon>
        </v-list-item-icon>
        <v-list-item-content>
          <v-list-item-title>{{ item.title }}</v-list-item-title>
        </v-list-item-content>
      </v-list-item>
      <v-list-group v-if="item.group" no-action :prepend-icon="item.icon">
        <template v-slot:activator>
          <v-list-item-title>{{ item.title }}</v-list-item-title>
        </template>
        <v-list-item
          v-for="(group, i) in item.group"
          :key="i"
          link
          @click="navigate(group.routeName, group.title)"
        >
          <v-list-item-title v-text="group.title"></v-list-item-title>
        </v-list-item>
      </v-list-group>
    </v-list>
  </div>
</template>

<script>
import { useNavigationStore } from "@/stores/navigation";

export default {
  setup() {
    const navigationStore = useNavigationStore();
    return { navigationStore };
  },
  data() {
    return {
      right: null,
    };
  },
  methods: {
    navigate: function (routeName, title) {
      if (routeName) {
        this.navigationStore.navigateToRoute(routeName, title);
      }
    },
  },
  computed: {
    getNavigationItems() {
      return this.navigationStore.getNavigationMenu();
    },
  },
  props: {
    // items: {
    //     type: Array,
    //     required: true
    // }
  },
};
</script>

<style>
</style>