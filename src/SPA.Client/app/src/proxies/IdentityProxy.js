export default class IdentityProxy {
  constructor(axios, url) {
    this.axios = axios
    this.url = url
  }
  login() {
    console.log('login...')
  }
}