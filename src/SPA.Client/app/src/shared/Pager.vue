<!-- eslint-disable vue/multi-word-component-names -->
<template>
    <nav class="pagination is-rounded" role="navigation" aria-label="pagination">
        <ul class="pagination-list">
            <li v-for="item in pages" :key="item">
                <a @click="go(item)" :class="{ 'is-current': item === page }" class="pagination-link">{{ item }}</a>
            </li>
        </ul>
    </nav>
</template>

<script>
export default {
    // eslint-disable-next-line vue/multi-word-component-names
    name: 'Pager',
    props: {
        page: {
            type: Number,
            required: true
        },
        pages: {
            type: Number,
            required: true
        },
        paging: {
            type: Function,
            required: true
        }
    },
    data() {
        return {

        }
    },
    methods: {
        go(page) {
            if(page === this.page) {
                return
            }
            this.paging(page)
        }
    }
}
</script>