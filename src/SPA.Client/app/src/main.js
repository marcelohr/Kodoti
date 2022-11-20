import { createApp } from "vue";
import Notifications from "@kyvg/vue3-notification";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { library } from "@fortawesome/fontawesome-svg-core";
import { faRightFromBracket, faSpinner } from "@fortawesome/free-solid-svg-icons";
import App from "./App.vue";
import router from "./router";
import proxyConfig from "./proxies/_config";
import { store } from "./store";

library.add(faRightFromBracket, faSpinner)

createApp(App)
  .use(router)
  .use(store)
  .use(Notifications)
  .use({
    install: (app) => {
      app.config.globalProperties.$proxies = proxyConfig;
      app.config.globalProperties.$user = () => {
        let token = localStorage.getItem("access_token").split(".");
        let user = JSON.parse(atob(token[1]));
        store.state.user = {
          id: user.nameid,
          email: user.email,
          roles: user.role,
        };
      };
    },
  })
  .component("font-awesome-icon", FontAwesomeIcon)
  .mount("#app");
