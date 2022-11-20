export default class ProductProxy {
  constructor(axios, url) {
    this.axios = axios;
    this.url = url;
  }

  getAll(page, take) {
    return this.axios.get(this.url + `products?page=${page}&take=${take}`);
  }
}
