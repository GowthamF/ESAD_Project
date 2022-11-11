import Vue from "vue";
import VueRouter from "vue-router";
import DashboardView from "../views/DashboardView.vue";
import HomeView from "../views/HomeView.vue";
import RCMView from "../views/RCMView.vue";
import JobListingView from "../views/JobListingView.vue";
import JobsNavigationView from "../views/JobsNavigationView.vue";
import JobsView from "../views/JobsView.vue";
import LoginView from "../views/LoginView.vue";
import EmploymentTypesView from "../views/EmploymentTypesView.vue";

Vue.use(VueRouter);

const router = new VueRouter({
  mode: "history",
  base: import.meta.env.BASE_URL,
  routes: [
    {
      path: "/",
      name: "dashboard",
      component: HomeView,

      children: [
        {
          path: "rcm",
          component: RCMView,
          children: [
            { path: "job-listing", component: JobListingView },
            {
              path: "admin",
              component: RCMView,
              children: [
                { path: "employment-types", component: EmploymentTypesView },
              ],
            },
          ],
        },
        {
          path: "",
          component: DashboardView,
        },
      ],
    },
    {
      path: "/public-jobs",
      name: "recruitment",
      component: JobsNavigationView,
      children: [{ path: "", component: JobsView, props: { isPublic: true } }],
      props: { isPublic: true },
    },
    {
      path: "/internal-jobs",
      name: "recruitment",
      component: JobsNavigationView,
      children: [{ path: "", component: JobsView, props: { isPublic: false } }],
      props: { isPublic: false },
    },
    {
      path: "/login",
      name: "Login",
      component: LoginView,
    },
    // {
    //   path: "/about",
    //   name: "about",
    //   // route level code-splitting
    //   // this generates a separate chunk (About.[hash].js) for this route
    //   // which is lazy-loaded when the route is visited.
    //   component: () => import("../views/AboutView.vue"),
    // },
  ],
});

router.beforeEach((to, from, next) => {
  var isAuthenticated = localStorage.getItem("user-token");
  if (to.name !== "Login" && !isAuthenticated) next({ name: "Login" });
  else next();
});

export default router;
