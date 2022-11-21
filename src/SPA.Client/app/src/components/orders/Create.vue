<!-- eslint-disable vue/multi-word-component-names -->
<template>
    <div>
        <h1 class="title">Create Order</h1>
        <h2 class="subtitle">Insert Data to Create an Order</h2>

        <template v-if="!isLoading">
            <div class="box">
                <div class="select is-fullwidth">
                    <select>
                        <option v-for="client in clients" :key="client.clientId" :value="client.clientId">
                            {{ client.name }}
                        </option>
                    </select>
                </div>
            </div>
            <div class="box">
                <table class="table is-fullwidth is-striped">
                    <thead>
                        <tr>
                            <th colspan="2">Product</th>
                            <th class="has-text-right" style="width:150px;">Qty</th>
                            <th class="has-text-right" style="width:150px;">U.P</th>
                            <th class="has-text-right" style="width:150px;">Subtotal</th>
                            <th class="has-text-right" style="width:150px;">IVA</th>
                            <th class="has-text-right" style="width:150px;">Total</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td colspan="2">
                                <div class="select is-fullwidth">
                                    <select>
                                        <option v-for="product in products" :key="product.productId" :value="product.productId">
                                            {{ product.name }}
                                        </option>
                                    </select>
                                </div>
                            </td>
                            <td>
                                <input class="input" type="number" />
                            </td>
                            <td>
                                <input class="input" type="number" />
                            </td>
                            <td colspan="3" class="has-text-right">
                                <button class="button">Add</button>
                            </td>
                        </tr>
                    </tbody>
                    <tfoot class="has-text-weight-bold">
                        <tr>
                            <td colspan="6" class="has-text-right">Subtotal</td>
                            <td class="has-text-right"></td>
                        </tr>
                        <tr>
                            <td colspan="6" class="has-text-right">IVA</td>
                            <td class="has-text-right"></td>
                        </tr>
                        <tr>
                            <td colspan="6" class="has-text-right">Total</td>
                            <td class="has-text-right"></td>
                        </tr>
                    </tfoot>
                </table>
            </div>
        </template>
        <Loader v-else />
    </div>
</template>

<script src="./Create.js"></script>