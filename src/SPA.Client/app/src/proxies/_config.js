import Axios from 'axios'
import IdentityProxy from './IdentityProxy.js'
import ProductProxy from './ProductProxy.js'
import UserProxy from './UserProxy.js'
import ClientProxy from './ClientProxy.js'
import OrderProxy from './OrderProxy.js'

// Axios default behavior
Axios.defaults.headers.common.Accept = 'application/json'
Axios.interceptors.request.use(
    config => {
        let token = localStorage.getItem('access_token')
        if(token) {
            config.headers.Authorization = `Bearer ${token}`
        }

        return config
    },
    error => Promise.reject(error)
)
let url = null

if(localStorage.getItem("config") !== null){
    let config = JSON.parse(localStorage.getItem("config"))
    url = config.apiUrl
}

export default {
    identityProxy: new IdentityProxy(Axios, url),
    userProxy: new UserProxy(Axios, url),
    productProxy: new ProductProxy(Axios, url),
    clientProxy: new ClientProxy(Axios, url),
    orderProxy: new OrderProxy(Axios, url)
}