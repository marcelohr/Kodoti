import Loader from '@/shared/Loader'
import Pager from '@/shared/Pager'

export default {
    name: 'IndexOrders',
    mounted() {
        this.getAll(1)
    },
    components: {
        Loader, Pager
    },
    data() {
        return {
            collection: {
                hasItems: false,
                items: [],
                page: 1,
                pages: 0,
                total: 0
            },
            isLoading: false
        }
    },
    methods: {
        getAll(page) {
            this.isLoading = true
            this.$proxies.orderProxy.getAll(page, 10).then(x => {
                this.collection = x.data
                this.isLoading = false
            })
        }
    }
}