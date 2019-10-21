import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

export const store = new Vuex.Store({
  state: {
    user: null
  },
  mutations: {
    login (state, user) {
      state.user = user;
    },
    logout (state) {
      state.user = null;
    }
  },
  action: {
    login (context) {
      context.commit('login')
    }
  }
})