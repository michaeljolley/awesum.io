<template>
  <div>
    <div v-if="!$auth.isAuthenticated && !$auth.loading">
      <a href="#" @click.prevent="login" class="btn btn-primary btn-login">
        <i class="fab fa-twitter"></i>
        <span class="d-none d-sm-inline">&nbsp;Login with Twitter</span>
      </a>
    </div>
    <div v-if="$auth.isAuthenticated && !$auth.loading">
      <div class="btn-group">
        <button
          type="button"
          class="btn dropdown-toggle"
          data-toggle="dropdown"
          aria-haspopup="true"
          aria-expanded="false"
        >
          <img :src="user.picture" class="user-picture" />
          <span class="d-none d-md-inline">{{user.name}}</span>
        </button>
        <div class="dropdown-menu dropdown-menu-right">
          <router-link class="dropdown-item" to="/moderate">Moderation</router-link>
          <a class="dropdown-item" href="#" @click.prevent="logout">
            Log Out
            <span class="pull-right glyphicon glyphicon-log-out"></span>
          </a>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Navigation",
  computed: {
    user() {
      if (this.$auth.user) {
        return this.$auth.user;
      }
      return null;
    }
  },
  methods: {
    login() {
      this.$auth.loginWithRedirect();
    },
    logout() {
      this.$auth.logout();
      this.$router.push({ path: "/" });
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.user-picture {
  width: 36px;
}
.btn-login {
  background-color: #55acee;
  border-color: #55acee;
}
.btn-login:hover,
.btn-login:active {
  background-color: #4387ba;
  border-color: #4387ba;
}
</style>
