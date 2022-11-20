<!-- eslint-disable vue/multi-word-component-names -->
<!-- eslint-disable vue/multi-word-component-names -->
<template>
  <div class="hero-head">
    <header class="navbar">
      <div class="container">
        <div class="navbar-brand">
          <a class="navbar-item">
            <img src="https://bulma.io/images/bulma-type-white.png" alt="Logo">
          </a>
          <span class="navbar-burger" data-target="navbarMenuHeroC">
            <span></span>
            <span></span>
            <span></span>
          </span>
        </div>
        <div id="navbarMenuHeroC" class="navbar-menu">
          <div class="navbar-end">
            <router-link :class="{'is-active' : $route.name === 'default'}" class="navbar-item" to="/">Home</router-link>
            <router-link :class="{'is-active' : $route.name === 'orders'}" class="navbar-item" to="/orders">Orders</router-link>
            <router-link :class="{'is-active' : $route.name === 'clients'}" class="navbar-item" to="/clients">Clients</router-link>
            <router-link :class="{'is-active' : $route.name === 'products'}" class="navbar-item" to="/products">Products</router-link>
            <router-link :class="{'is-active' : $route.name === 'users'}" v-if="user.roles.includes('Admin')" class="navbar-item" to="/users">Users</router-link>
            <span class="navbar-item">
              <a @click="logout" class="button is-danger is-inverted">
                <font-awesome-icon icon="fa-solid fa-right-from-bracket" />
                <span>Logout</span>
              </a>
            </span>
          </div>
        </div>
      </div>
    </header>
  </div>
</template>

<script>
export default {
  // eslint-disable-next-line vue/multi-word-component-names
  name: 'Header',
  data() {
    return {
      user: this.$store.state.user
    }
  },
  methods: {
    logout() {
      localStorage.removeItem("access_token")
      this.$parent.isLoggedIn = false
    }
  }
}
</script>