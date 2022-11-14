import { createApp } from "vue";
import Notifications from "@kyvg/vue3-notification"
import App from "./App.vue";
import router from "./router";
import proxyConfig from "./proxies/_config";

createApp(App).use(router).use(Notifications).use({
  install: (app) => {
    app.config.globalProperties.$proxies = proxyConfig;
  }
}).mount("#app");