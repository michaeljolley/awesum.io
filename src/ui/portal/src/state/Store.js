import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";
import getInstance from "../auth/authService";

import * as types from "./Mutations";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    userGramercies: [],
    pendingGramercies: []
  },
  mutations: {
    login(state, gramercies) {
      state.userGramercies = gramercies;
    },
    logout(state) {
      state.userGramercies = null;
    },
    loadPending(state, gramercies) {
      state.pendingGramercies = gramercies;
    }
  },
  actions: {
    async login(context, user) {
      const recipientId = user.sub.replace("twitter|", "");
      const url = `https://awesum-func.azurewebsites.net/api/GramerciesByUser?recipientid=${recipientId}`;

      const userGramercies = await axios.post(
        url,
        {},
        {
          "Content-Type": "application/json"
        }
      );

      context.commit(types.USER_LOG_IN, userGramercies.data);
    },
    logout(context) {
      context.commit(types.USER_LOG_OUT);
    },
    async loadPending(context) {
      const url = `https://awesum-func.azurewebsites.net/api/PendingGramercies`;

      const auth = getInstance;

      // eslint-disable-next-line no-console
      console.dir(auth);

      const pendingGramercies = await axios.post(
        url,
        {},
        {
          "Content-Type": "application/json",
          Authorization: `BEARER ${this.$auth.user}`
        }
      );

      context.commit(types.LOAD_PENDING, pendingGramercies.data);
    }
  }
});
