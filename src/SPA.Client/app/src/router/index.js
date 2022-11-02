import { createRouter, createWebHistory } from 'vue-router'
import Default from '../components/Default.vue'

const routes = [
  {
    path: '/',
    name: 'default',
    component: Default
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
