import Loader from '../../shared/Loader.vue'

export default {
    name: 'CreateOrder',
    mounted() {
        this.initialize()
    },
    components: {
        Loader
    },
    data() {
        return {
            clients: [],
            products: [],
            isLoading: false
        }
    },
    methods: {
        initialize() {
            this.isLoading = true
            let clients = this.$proxies.clientProxy.getAll(1, 100)
            let products = this.$proxies.productProxy.getAll(1, 100)
            Promise.all([clients, products])
            .then(values => {
                this.clients = values[0].data.items
                this.products = values[1].data.items
                this.isLoading = false
            })
        }
    }
}