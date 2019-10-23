<template>
  <div>
      <div v-if="!$auth.isAuthenticated && !$auth.loading">
        <a href="#" @click.prevent="login" class="btn btn-primary">
          Login
        </a>
      </div>
      <div v-if="$auth.isAuthenticated && !$auth.loading">
        <div class="btn-group">
          <button type="button" class="btn dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            <img :src="user.picture"/> {{user.name}}
          </button>
          <div class="dropdown-menu">
            <a class="dropdown-item" href="#">Moderation</a>
            <a class="dropdown-item" href="#" @click.prevent="logout">
              Log Out <span class="pull-right glyphicon glyphicon-log-out"></span>
            </a>
          </div>
        </div>
      </div>
  </div>
</template>

<script>
export default {
  name: 'Navigation',
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
      this.$router.push({ path: '/' });
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
