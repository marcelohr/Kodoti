<!-- eslint-disable vue/multi-word-component-names -->
<template>
    <div>
        <h1 class="title">{{ model.productId ? model.name : 'New Product' }}</h1>
        <h2 class="subtitle"> {{ model.productId ? model.description : 'Insert Data to Register a Product' }} </h2>

        <form v-if="!isLoading" @submit.prevent="save">
            <div class="field">
                <input v-model="model.name" required minlength="3" maxlength="100" autocomplete="false" class="input"
                    type="text" placeholder="Enter Name" />
            </div>
            <div class="field">
                <input v-model.number="model.price" required min="1" autocomplete="false" class="input" type="number"
                    placeholder="Enter UnitPrice" />
            </div>
            <div class="field">
                <textarea v-model="model.description" required maxlength="250" rows="2" autocomplete="false"
                    class="textarea" placeholder="Enter Description"></textarea>
            </div>
            <div class="field">
                <button type="submit" class="button is-success">Confirm</button>
            </div>
        </form>
        <Loader v-else />
    </div>
</template>

<script src="./Save.js"></script>