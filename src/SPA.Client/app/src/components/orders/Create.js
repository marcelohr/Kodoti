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
            model: {
                clientId: null,
                items: [

                ]
            },
            product: {
                productId: null,
                quantity: 1,
                unitPrice: 0
            },
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

                this.model.clientId = this.clients[0].clientId
                this.product.productId = this.products[0].productId

                this.onChangeProductSelection()

                this.isLoading = false
            })
        },
        onChangeProductSelection() {
            let product = this.products.find(
                x => x.productId == this.product.productId
            )
            this.product.quantity = 1
            this.product.unitPrice = product.price
            console.log(this.product)
        },
        addProduct() {
            if(!this.model.items.some(x => x.productId === this.product.productId)) {
                // lo recomendado es que venga desde el server
                const ivaRate = 0.15
                let item = {
                    // son los obligatorios del servidor 
                    productId: this.product.productId,
                    unitPrice: this.product.unitPrice,
                    quantity: this.product.quantity,

                    //
                    name: this.products.find(x => x.productId === this.product.productId).name,
                    total: this.product.quantity * this.product.unitPrice
                }
                item.iva = ivaRate * item.total
                item.subTotal = item.total - item.iva
                this.model.items.push(item)
                this.onChangeProductSelection()
            }
        }
    }
}