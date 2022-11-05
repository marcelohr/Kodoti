<template>
  <section id="app" class="hero is-light is-bold is-fullheight">
    <template v-if="hasConfig">
      <Header></Header>
      <div class="hero-body">
        <div class="container has-text-centered">
          <router-view />
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
export default {
  name: "app",
  mounted() {
    this.initiliaze()
  },
  components: {
    // eslint-disable-next-line vue/no-unused-components
    Header,
    Footer
  },
  data() {
    return {
      hasConfig: false
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
        })

      function __prepareConfig() {
        if (!localStorage.getItem("config")) {
          fetch('/config')
            .then(x => x.json())
            .then(x => {
              localStorage.setItem("config", JSON.stringify(x));
              self.hasConfig = true
            })
        } else {
          self.hasConfig = true
        }
      }
    }
  }
}
</script>