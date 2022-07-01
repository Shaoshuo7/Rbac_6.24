import Vue from 'vue'
import VueRouter from 'vue-router'
import HomeView from '../views/HomeView.vue'

Vue.use(VueRouter)

const routes = [
 
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  },
  {
    path: '/Login',
    name: '登录',
    component: () => import('../views/Login.vue')
  },
  {
    path: '/Enroll',
    name: 'Enroll',
    component: () => import('../views/Enroll.vue')
  },
  {
    path: '/RoleAndMeun',
    name: 'RoleAndMeun',
    component: () => import('../views/RoleAndMeun.vue')
  },
  {
    path: '/',
    name: 'Home',
    component: () => import('../views/Home.vue'),
    children:[
      {path: '/',component: () => import('../views/Welcome.vue')},
      {path: '/MeunShow',name: 'MeunShow',component: () => import('../views/MeunShow.vue')},
      {path: '/MeunAdd',name: 'MeunAdd',component: () => import('../views/MeunAdd.vue')},
      {path: '/MeunUpd',name: 'MeunUpd',component: () => import('../views/MeunUpd.vue')},
      {path: '/RoleShow',name: 'RoleShow',component: () => import('../views/RoleShow.vue')},
      {path: '/RoleAdd',name: 'RoleAdd',component: () => import('../views/RoleAdd.vue')},
      {path: '/RoleUpd',name: 'RoleUpd',component: () => import('../views/RoleUpd.vue')},
      {path: '/AdminShow',name: 'AdminShow',component: () => import('../views/AdminShow.vue')},
    ]
  }
]

const router = new VueRouter({
  routes
})
router.beforeEach((t,f,n)=>{
  let LogName = sessionStorage.getItem("LogName")??""
  if(t.name !== '登录' && LogName==0){
    n({name:'登录'})
  }
  else{
    n()
  }
})

export default router
