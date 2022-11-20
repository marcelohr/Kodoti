<!-- eslint-disable vue/multi-word-component-names -->
<template>
    <div>
        <h1 class="title">Users</h1>
        <h2 class="subtitle">Desde aqui puede gestionar sus usuarios</h2>

        <template v-if="!isLoading">
            <table class="table is-striped is-fullwidth">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Email</th>
                        <th>Role</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in collection.items" :key="item.id">
                        <td>{{ item.id }}</td>
                        <td>{{ item.email }}</td>
                        <td>{{ item.roles }}</td>
                    </tr>
                </tbody>
            </table>
            <Pager :paging="x => this.getAll(x)" :page="collection.page" :pages="collection.pages" />
        </template>
        <Loader v-else />
    </div>
</template>

<script src="./Index.js"></script>