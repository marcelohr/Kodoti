import { createRouter, createWebHistory } from "vue-router";
import Default from "../components/Default.vue";
import IndexClients from "../components/clients/Index.vue";
import SaveClients from "../components/clients/Save.vue"
import IndexOrders from "../components/orders/Index.vue";
import CreateOrder from "../components/orders/Create.vue"
import IndexProducts from "../components/products/Index.vue";
import SaveProduct from "../components/products/Save.vue"
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
    path: "/orders/create",
    name: "createOrder",
    component: CreateOrder
  },
  {
    path: "/clients",
    name: "clients",
    component: IndexClients
  },
  {
    path: "/clients/create",
    name: "saveClient",
    component: SaveClients
  },
  {
    path: "/products",
    name: "products",
    component: IndexProducts
  },
  {
    path: "/products/create",
    name: "saveProduct",
    component: SaveProduct
  },
  {
    path: "/products/:id/edit",
    name: "editProduct",
    component: SaveProduct
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
