export default class OrderProxy {
    constructor(axios, url) {
        this.axios = axios
        this.url = url
    }

    getAll(page, take) {
        return this.axios.get(this.url + `orders?page=${page}&take=${take}`)
    }

    getById(id) {
        return this.axios.get(this.url + `orders/${id}`)
    }

    create(params) {
        return this.axios.post(this.url + `orders`, params)
    }
}