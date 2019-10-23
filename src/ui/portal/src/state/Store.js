import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";

import * as types from "./Mutations";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    gramercies: []
  },
  getters: {
    usersGramercies: state => state.gramercies
  },
  mutations: {
    login(state, gramercies) {
      state.gramercies = gramercies;
    },
    logout(state) {
      state.gramercies = null;
    }
  },
  actions: {
    async login(context, user) {
      const recipientId = user.sub.replace("twitter|", "");
      const url = `https://awesum-func.azurewebsites.net/api/GramerciesByUser?recipientid=${recipientId}`;

      const gramercies = await axios.post(
        url,
        {},
        {
          "Content-Type": "application/json"
        }
      );

      context.commit(types.USER_LOG_IN, gramercies.data);
    },
    logout(context) {
      context.commit(types.USER_LOG_OUT);
    }
  }
});
