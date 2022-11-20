<!-- eslint-disable vue/multi-word-component-names -->
<template>
    <div>
        <h1 class="title">Products</h1>
        <h2 class="subtitle">Desde aqui puede gestionar sus productos</h2>
    </div>

    <template v-if="!isLoading">
            <table class="table is-striped is-fullwidth">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Description</th>
                    <th>UnitPrice</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in collection.items" :key="item.id">
                    <td>{{ item.productId }}</td>
                    <td>{{ item.name }}</td>
                    <td>{{ item.description }}</td>
                    <td>{{ item.price }}</td>
                </tr>
            </tbody>
        </table>
        <Pager :paging="x => this.getAll(x)" :page="collection.page" :pages="collection.pages" />
        </template>
</template>

<script src="./Index.js"></script>