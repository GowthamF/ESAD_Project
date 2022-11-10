import { defineStore } from "pinia";
import axios from "axios";

// main is the name of the store. It is unique across your application
// and will appear in devtools
export const useLoginStore = defineStore("loginStore", {
  state: () => ({
    identityServiceUrl: import.meta.env.VITE_IDENTITY_URL,
    authError: null,
    authenticated: false,
    authenticating: false,
    loggedOut: false,
  }),
  actions: {
    async login(userName, password) {
      try {
        this.$state.loggedOut = false;
        this.$state.authenticating = true;
        var response = await axios.post(
          `${this.$state.identityServiceUrl}/Account/Token`,
          { userName, password }
        );
        this.$state.authenticated = true;
        localStorage.setItem("user-token", response.data.token);
        this.$state.authenticating = false;
        // this.$router.replace("/");
      } catch (error) {
        return [];
      }
    },
    logout() {
      localStorage.removeItem("user-token");
      window.location.reload();
    },
  },
});
