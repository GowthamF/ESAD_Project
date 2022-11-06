import Vue from "vue";
import { markRaw } from "vue";

import App from "./App.vue";
import router from "./router";
import vuetify from "@/plugins/vuetify";
import { createPinia, PiniaVuePlugin } from "pinia";

Vue.use(PiniaVuePlugin);
const pinia = createPinia();

pinia.use(({ store }) => {
  store.$router = markRaw(router);
});

new Vue({
  vuetify,
  router,
  pinia,
  render: (h) => h(App),
}).$mount("#app");
