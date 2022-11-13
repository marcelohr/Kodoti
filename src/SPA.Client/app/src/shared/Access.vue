<!-- eslint-disable vue/multi-word-component-names -->
<template>
    <div class="columns is-centered">
        <div class="column is-6">
            <div class="box">
                <div class="tabs is-boxed">
                    <ul>
                        <li :class="{ 'is-active': tab === 'login' }">
                            <a @click="tab = 'login'">Login</a>
                        </li>
                        <li :class="{ 'is-active': tab === 'register' }">
                            <a @click="tab = 'register'">Register</a>
                        </li>
                    </ul>
                </div>
                <form v-if="tab === 'login'">
                    <div class="field">
                        <input class="input" type="text" placeholder="Ingrese su correo">
                    </div>
                    <div class="field">
                        <input class="input" type="password" placeholder="Ingrese su clave">
                    </div>
                    <div class="field">
                        <button class="button is-primary" type="button">Entrar</button>
                    </div>
                </form>
                <form v-if="tab === 'register'">
                    <div class="field">
                        <input class="input" type="text" placeholder="Ingrese su correo">
                    </div>
                    <div class="field">
                        <input class="input" type="password" placeholder="Ingrese su clave">
                    </div>
                    <div class="field">
                        <button class="button is-primary" type="button">Registrarse</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    // eslint-disable-next-line vue/multi-word-component-names
    name: 'Access',
    data() {
        return {
            tab: 'login'
        }
    }
}
</script>