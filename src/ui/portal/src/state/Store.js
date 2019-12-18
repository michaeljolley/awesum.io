import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";

import * as types from "./Mutations";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    userGramercies: [],
    pendingGramercies: [],
    loading: false
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
    },
    loading(state, isLoading) {
      state.loading = isLoading;
    },
    saveGramercy(state, gramercy) {
      const tempGramercies = state.pendingGramercies.filter(
        f => f.id !== gramercy.id
      );
      tempGramercies.push(gramercy);
      state.pendingGramercies = tempGramercies;
    }
  },
  actions: {
    async login(context, user) {
      context.commit(types.LOADING, true);

      const recipientId = user.sub.replace("twitter|", "");
      const url = `https://awesum-func.azurewebsites.net/api/GramerciesByUser?recipientId=${recipientId}`;

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
    async loadPending(context, payload) {
      context.commit(types.LOADING, true);

      const url = `https://awesum-func.azurewebsites.net/api/PendingGramercies`;

      const pendingGramercies = await axios.post(
        url,
        {},
        {
          "Content-Type": "application/json",
          headers: {
            Authorization: `Bearer ${payload.id_token}`
          }
        }
      );
      context.commit(types.LOAD_PENDING, pendingGramercies.data);
    },
    loaded(context) {
      context.commit(types.LOADING, false);
    },
    async saveGramercy(context, payload) {
      context.commit(types.LOADING, true);

      const url = `https://awesum-func.azurewebsites.net/api/SaveGramercy?gramercyId=${payload.gramercyId}&status=${payload.status}`;

      const savedGramercy = await axios.post(
        url,
        {},
        {
          "Content-Type": "application/json",
          headers: {
            Authorization: `Bearer ${payload.id_token}`
          }
        }
      );
      context.commit(types.SAVE_GRAMERCY, savedGramercy.data);
    }
  }
});
