export default class IdentityProxy {
  constructor(axios, url) {
    this.axios = axios
    this.url = url
  }

  register (params) {
    return this.axios.post(this.url + 'identity/register', params);
  }

  login() {
    console.log('login...')
  }
}