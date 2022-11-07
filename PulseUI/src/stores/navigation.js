import { defineStore } from "pinia";

// main is the name of the store. It is unique across your application
// and will appear in devtools

export const useNavigationStore = defineStore("navigationStore", {
  state: () => ({
    currentRoute: "/",
    items: [
      { title: "Home", icon: "mdi-home", routeName: "/", isHome: true },
      {
        title: "eRecruitment",
        icon: "mdi-image",
        routeName: "/rcm",
      },
      { title: "Onboarding", icon: "mdi-help-box", routeName: "/onboarding" },
      { title: "Security", icon: "mdi-help-box", routeName: "/security" },
      {
        title: "Job Listing",
        icon: "mdi-help-box",
        routeName: "/rcm/job-listing",
        moduleName: "RCM",
      },
      {
        title: "Admin",
        icon: "mdi-help-box",
        routeName: "/rcm/admin",
        moduleName: "RCM",
      },
    ],
  }),
  getters: {
    getNavigationMenu: (state) => {
      return () => {
        if (state.currentRoute.includes("/rcm")) {
          return state.items.filter((x) => x.moduleName === "RCM" || x.isHome);
        }

        return state.items.filter((x) => x.moduleName !== "RCM");
      };
    },
  },
  actions: {
    navigateToRoute(routeName) {
      if (this.$state.currentRoute !== routeName) {
        this.$router.push(routeName);
        this.$state.currentRoute = this.$router.currentRoute.fullPath;
      }
    },
    addDefaultRoute() {
      this.$state.currentRoute = this.$router.currentRoute.fullPath;
    },
  },
});
