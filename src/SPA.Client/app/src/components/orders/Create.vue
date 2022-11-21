<!-- eslint-disable vue/multi-word-component-names -->
<template>
    <div>
        <h1 class="title">Create Order</h1>
        <h2 class="subtitle">Insert Data to Create an Order</h2>

        <template v-if="!isLoading">
            <div class="box">
                <div class="select is-fullwidth">
                    <select v-model.number="model.clientId">
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
                                    <select @change="onChangeProductSelection" v-model.number="product.productId">
                                        <option v-for="product in products" :key="product.productId" :value="product.productId">
                                            {{ product.name }}
                                        </option>
                                    </select>
                                </div>
                            </td>
                            <td>
                                <input v-model.number="product.quantity" class="input" type="number" />
                            </td>
                            <td>
                                <input v-model.number="product.unitPrice" class="input" type="number" />
                            </td>
                            <td colspan="3" class="has-text-right">
                                <button @click="addProduct" class="button">Add</button>
                            </td>
                        </tr>
                        <tr v-if="model.items.length === 0">
                            <td colspan="7" class="has-text-centered has-text-danger">
                                Product not selected
                            </td>
                        </tr>
                        <tr v-else v-for="item in model.items" :key="item.productId">
                            <td class="has-text-centered has-text-danger" sytle="width:100px;">
                                <a @click="removeProduct(item.productId)">Remove</a>
                            </td>
                            <td>
                                {{item.name}}
                            </td>
                            <td class="has-text-right">{{item.quantity}}</td>
                            <td class="has-text-right">USD {{item.unitPrice}}</td>
                            <td class="has-text-right">USD {{item.subTotal}}</td>
                            <td class="has-text-right">USD {{item.iva}}</td>
                            <td class="has-text-right">USD {{item.total}}</td>
                        </tr>
                    </tbody>
                    <tfoot class="has-text-weight-bold">
                        <tr>
                            <td colspan="6" class="has-text-right">USD {{subTotal}}</td>
                            <td class="has-text-right"></td>
                        </tr>
                        <tr>
                            <td colspan="6" class="has-text-right">USD {{iva}}</td>
                            <td class="has-text-right"></td>
                        </tr>
                        <tr>
                            <td colspan="6" class="has-text-right">USD {{total}}</td>
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