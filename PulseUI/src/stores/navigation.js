import { defineStore } from "pinia";

// main is the name of the store. It is unique across your application
// and will appear in devtools

export const useNavigationStore = defineStore("navigationStore", {
  state: () => ({
    currentRoute: "/",
    items: [
      { title: "Home", icon: "mdi-home", routeName: "/" },
      { title: "eRecruitment", icon: "mdi-image", routeName: "/rcm" },
      { title: "Onboarding", icon: "mdi-help-box", routeName: "/onboarding" },
      { title: "Security", icon: "mdi-help-box", routeName: "/security" },
    ],
  }),
  getters: {
    getNavigationMenu: (state) => {
      return () => {
        if (state.currentRoute === "/rcm") {
          return state.items.filter((x) => x.title === "Home");
        }

        return state.items;
      };
    },
  },
  actions: {
    multiply() {
      this.counter = ++this.counter;
    },
    navigateToRoute(routeName) {
      if (this.$state.currentRoute !== routeName) {
        this.$router.push(routeName);
        this.$state.currentRoute = this.$router.currentRoute.fullPath;
      }
    },
  },
});
