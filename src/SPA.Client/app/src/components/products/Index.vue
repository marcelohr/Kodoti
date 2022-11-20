<!-- eslint-disable vue/multi-word-component-names -->
<template>
    <div>
        <h1 class="title">Products</h1>
        <h2 class="subtitle">Desde aqui puede gestionar sus productos</h2>
        <div class="has-text-right field">
            <router-link to="/products/create" class="button is-info">Add New Product</router-link>
        </div>
        <template v-if="!isLoading">
            <table class="table is-striped is-fullwidth">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Description</th>
                        <th>UnitPrice</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in collection.items" :key="item.id">
                        <td>{{ item.productId }}</td>
                        <td>{{ item.name }}</td>
                        <td>{{ item.description }}</td>
                        <td>USD {{ item.price }}</td>
                        <td>
                            <router-link :to="`/products/${item.productId}/edit`">
                                Edit
                            </router-link>
                            -
                            <a @click="remove(item.productId)">
                                Delete
                            </a>
                        </td>
                    </tr>
                </tbody>
            </table>
            <Pager :paging="x => this.getAll(x)" :page="collection.page" :pages="collection.pages" />
        </template>
        <Loader v-else />
    </div>
</template>

<script src="./Index.js"></script>