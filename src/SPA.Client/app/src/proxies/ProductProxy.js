export default class ProductProxy {
  constructor(axios, url) {
    this.axios = axios;
    this.url = url;
  }

  getAll(page, take) {
    return this.axios.get(this.url + `products?page=${page}&take=${take}`);
  }

  getById(id) {
    return this.axios.get(this.url + `products/${id}`)
  }

  create(params) {
    return this.axios.post(this.url + `products`, params)
  }

  update(id, params) {
    return this.axios.put(this.url + `products/${id}`, params)
  }
}
