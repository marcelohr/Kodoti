<!-- eslint-disable vue/multi-word-component-names -->
<template>
    <div>
        <h1 class="title">KODOTI APP</h1>
        <h2 class="subtitle">Tu APP de gestion de ventas</h2>
        <p><b>{{ user.email }}</b> desde esta APP podras gestionar las ventas de tu negocio.</p>
    </div>
</template>

<script>
export default {
    data() {
        return {
            user: this.$store.state.user
        }
    }
}
</script>