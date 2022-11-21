<!-- eslint-disable vue/multi-word-component-names -->
<template>
    <div>
        <h1 class="title">Orders</h1>
        <h2 class="subtitle">Desde aqui puede gestionar sus ordenes</h2>
        <div class="has-text-right field">
            <router-link to="/orders/create" class="button is-info">Add New Product</router-link>
        </div>
        <template v-if="!isLoading">
            <table class="table is-striped is-fullwidth">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Client</th>
                        <th>Items</th>
                        <th>Total</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in collection.items" :key="item.id">
                        <td>{{ item.orderId }}</td>
                        <td>{{ item.client.name }}</td>
                        <td>{{ collection.items.length }}</td>
                        <td>USD {{ item.total }}</td>
                    </tr>
                </tbody>
            </table>
            <Pager :paging="x => this.getAll(x)" :page="collection.page" :pages="collection.pages" />
        </template>
        <Loader v-else />
    </div>
</template>

<script src="./Index.js"></script>