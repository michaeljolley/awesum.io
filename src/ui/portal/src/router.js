import Vue from 'vue';
import Router from 'vue-router';
import { authGuard } from './auth';

import Home from '@/views/Home.vue';
import Moderate from '@/views/Moderate.vue';

Vue.use(Router);

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/moderate',
      name: 'Moderate',
      component: Moderate,
      beforeEnter: authGuard
    }
  ]
});