export default class ClientProxy {
    constructor(axios, url) {
      this.axios = axios;
      this.url = url;
    }
  
    getAll(page, take) {
      return this.axios.get(this.url + `clients?page=${page}&take=${take}`)
    }

    getById(id) {
      return this.axios.get(this.url + `clients/${id}`)
    }

    create(params) {
      return this.axios.post(this.url + `clients`, params)
    }
  }