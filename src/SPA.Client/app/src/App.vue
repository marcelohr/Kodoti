<template>
  <section id="app" class="hero is-light is-fullheight">
    <notifications group="global" />
    <template v-if="hasConfig">
      <Header v-if="isLoggedIn"></Header>
      <div class="hero-body">
        <div class="container">
          <router-view v-if="isLoggedIn" />
          <Access v-else></Access>
        </div>
      </div>
      <Footer></Footer>
    </template>
    <div v-else class="hero-body">
      <div class="container has-text-centered is-size-5">
        <p>- Estamos inicializando el proyecto, un momento porfavor... -</p>
      </div>
    </div>
  </section>
</template>

<script>
import Header from '@/shared/Header.vue'
import Footer from '@/shared/Footer.vue'
import Access from '@/shared/Access.vue'
export default {
  name: "app",
  mounted() {
    this.initiliaze()
    this.$proxies.identityProxy.login()
  },
  components: {
    // eslint-disable-next-line vue/no-unused-components
    Header,
    Footer,
    Access
  },
  data() {
    return {
      hasConfig: false,
      isLoggedIn: false
    }
  },
  methods: {
    initiliaze() {
      let self = this;

      fetch('config/version')
        .then(x => x.text())
        .then(x => {
          if (!localStorage.getItem("version") || localStorage.getItem("version") != x) {
            localStorage.clear()
            localStorage.setItem("version", x)
          }
          __prepareConfig()
          __isLoggedIn()
        })

      function __prepareConfig() {
        if (!localStorage.getItem("config")) {
          fetch('/config')
            .then(x => x.json())
            .then(x => {
              localStorage.setItem("config", JSON.stringify(x));
              self.hasConfig = true
              window.location.reload(true)
            })
        } else {
          self.hasConfig = true
        }
      }
      function __isLoggedIn() {
        if (localStorage.getItem("access_token") != null) {
          self.isLoggedIn = true
        }
      }
    }
  }
}
</script>