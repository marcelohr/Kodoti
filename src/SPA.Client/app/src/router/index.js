import { createRouter, createWebHistory } from "vue-router";
import Default from "../components/Default.vue";
import IndexClients from "../components/clients/Index.vue";
import IndexOrders from "../components/orders/Index.vue";
import IndexProducts from "../components/products/Index.vue";
import IndexUsers from "../components/users/Index.vue";
import { store } from "../store";

const routes = [
  {
    path: "/",
    name: "default",
    component: Default,
    beforeEnter() {}
  },
  {
    path: "/orders",
    name: "orders",
    component: IndexOrders
  },
  {
    path: "/clients",
    name: "clients",
    component: IndexClients
  },
  {
    path: "/products",
    name: "products",
    component: IndexProducts
  },
  {
    path: "/users",
    name: "users",
    component: IndexUsers,
    beforeEnter: authorization
  }
];

function authorization(to, from, next) {
  let user = store.state.user;
  if (user) {
    if (to.name === "users" && !user.roles.includes("Admin")) {
      return next("/");
    }
  }
  
  return next();
}

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
