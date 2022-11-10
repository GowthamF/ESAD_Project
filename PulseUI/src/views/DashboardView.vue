<template>
  <div>
    <v-container fluid>
      <v-card max-width="50%" class="mx-auto">
        <v-app-bar color="white"><h2>Notifications</h2></v-app-bar>
        <v-virtual-scroll
          :bench="benched"
          :items="items"
          item-height="64"
          height="500px"
        >
          <template v-slot:default="{ item }">
            <v-list-item :key="item">
              <v-list-item-action>
                <v-icon large color="primary"> mdi-email </v-icon>
              </v-list-item-action>

              <v-list-item-content>
                <v-list-item-title>
                  Employee request is waiting for your approval
                </v-list-item-title>
              </v-list-item-content>

              <v-list-item-action>
                <v-icon small> mdi-open-in-new </v-icon>
              </v-list-item-action>
            </v-list-item>

            <v-divider></v-divider>
          </template>
        </v-virtual-scroll>
      </v-card>
    </v-container>
  </div>
</template>

<script>
export default {
  data: () => ({
    benched: 0,
  }),
  computed: {
    items() {
      return Array.from({ length: this.length }, (k, v) => v + 1);
    },
    length() {
      return 100;
    },
  },
};
</script>

<style>
</style>