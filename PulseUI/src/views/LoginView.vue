<template>
  <div>
    <v-app>
      <v-layout justify-center align-center>
        <v-form
          ref="form"
          v-model="valid"
          lazy-validation
          class="d-flex flex-column mb-6 col-md-3 .ml-md-auto"
        >
          <v-text-field
            v-model="emailAddress"
            :rules="[rules.required, rules.min, rules.email]"
            label="Email Address"
            required
            outlined
          ></v-text-field>

          <v-text-field
            outlined
            v-model="password"
            :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
            :rules="[rules.required, rules.min]"
            :type="show1 ? 'text' : 'password'"
            name="input-10-1"
            label="Password"
            hint="At least 8 characters"
            @click:append="show1 = !show1"
          ></v-text-field>

          <v-btn
            :disabled="getAuthenticationState"
            color="primary"
            outlined
            @click="login"
          >
            Login
          </v-btn>
        </v-form>
      </v-layout>
    </v-app>
  </div>
</template>

<script>
import { useLoginStore } from "@/stores/login";
import { useNavigationStore } from "@/stores/navigation";
import { storeToRefs } from "pinia";

export default {
  setup() {
    const loginStore = useLoginStore();
    const navigationStore = useNavigationStore();
    navigationStore.addDefaultRoute();
    const { authenticating, loggedOut } = storeToRefs(loginStore);
    return { loginStore, authenticating, navigationStore, loggedOut };
  },
  data() {
    return {
      show1: false,
      valid: true,
      password: "",
      emailAddress: "",
      rules: {
        required: (value) => !!value || "Required.",
        min: (v) => v.length >= 8 || "Min 8 characters",
        email: (value) => {
          const pattern =
            /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
          return pattern.test(value) || "Invalid e-mail.";
        },
      },
    };
  },
  methods: {
    login() {
      if (this.$refs.form.validate()) {
        this.loginStore.login(this.emailAddress, this.password);
      }
    },
  },
  computed: {
    getAuthenticationState() {
      return this.loginStore.authenticating;
    },
  },
  watch: {
    authenticating(newValue) {
      if (!newValue) {
        this.navigationStore.navigateToRoute("/");
      }
    },
    loggedOut(newValue) {
      if (newValue) {
        window.location.reload();
      }
    },
  },
};
</script>

<style>
</style>