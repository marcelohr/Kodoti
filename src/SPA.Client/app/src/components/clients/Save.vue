<!-- eslint-disable vue/multi-word-component-names -->
<template>
    <div>
        <h1 class="title">
            New Client
        </h1>
        <h2 class="subtitle">
            Insert Data to Register New Client
        </h2>
        <form v-if="!isLoading" @submit.prevent="save">
            <div class="field">
                <input v-model="model.name" required minlength="3" maxlength="100" type="text" autocomplete="false"
                    class="input" placeholder="Enter FullName" />
            </div>
            <div class="field">
                <button type="submit" class="button is-success">Confirm</button>
            </div>
        </form>
        <Loader v-else></Loader>
    </div>
</template>

<script src="./Save.js"></script>