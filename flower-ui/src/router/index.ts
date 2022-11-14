import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import HomePage from '../views/HomePage.vue'

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'home',
    component: HomePage
  }, {
    path: '/pay',
    name: 'pay',
    component: () => import('../views/FlowerPay.vue')
  }
  ,
  {
    path: '/personalcenter',
    name: 'personalcenter',
    component: () => import('../views/PersonalCenter.vue')
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
