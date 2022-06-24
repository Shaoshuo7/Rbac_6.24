import Vue from 'vue'
import VueRouter from 'vue-router'
import HomeView from '../views/HomeView.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  },
  {
    path: '/MeunShow',
    name: 'MeunShow',
    component: () => import('../views/MeunShow.vue')
  },
  {
    path: '/MeunAdd',
    name: 'MeunAdd',
    component: () => import('../views/MeunAdd.vue')
  },
  {
    path: '/MeunUpd',
    name: 'MeunUpd',
    component: () => import('../views/MeunUpd.vue')
  },
  {
    path: '/RoleShow',
    name: 'RoleShow',
    component: () => import('../views/RoleShow.vue')
  },
  {
    path: '/RoleAdd',
    name: 'RoleAdd',
    component: () => import('../views/RoleAdd.vue')
  },
  {
    path: '/RoleUpd',
    name: 'RoleUpd',
    component: () => import('../views/RoleUpd.vue')
  }
]

const router = new VueRouter({
  routes
})

export default router