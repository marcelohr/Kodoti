import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import proxyConfig from "./proxies/_config";

createApp(App).use(router).use({
  install: (app) => {
    app.config.globalProperties.$proxies = proxyConfig;
  }
}).mount("#app");