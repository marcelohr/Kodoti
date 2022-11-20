<!-- eslint-disable vue/multi-word-component-names -->
<template>
    <div>
        <h1 class="title">Clients</h1>
        <h2 class="subtitle">Desde aqui puede gestionar sus clientes</h2>
        <div class="has-text-right field">
            <router-link to="/clients/create" class="button is-info">Add New Client</router-link>
        </div>
        <template v-if="!isLoading">
            <table class="table is-striped is-fullwidth">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in collection.items" :key="item.id">
                        <td>{{ item.clientId }}</td>
                        <td>{{ item.name }}</td>
                    </tr>
                </tbody>
            </table>
            <Pager :paging="x => this.getAll(x)" :page="collection.page" :pages="collection.pages" />
        </template>
        <Loader v-else />
    </div>
</template>

<script src="./Index.js"></script>