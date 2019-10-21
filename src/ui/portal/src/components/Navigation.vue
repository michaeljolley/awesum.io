<template>
  <div>
      <div >
        <input type="button" class="btn btn-primary" id="login" value="Login" />
      </div>
      <div >
        <div class="btn-group">
          <button type="button" class="btn dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            
          </button>
          <div class="dropdown-menu">
            <a class="dropdown-item" href="#">Moderation</a>
            <a class="dropdown-item" href="#">Logout</a>
          </div>
        </div>
      </div>
  </div>
</template>

<script>
export default {
  name: 'Navigation',
  prop: {
  },
  computed: {
    loggedInUser () {
      return this.$store.user
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
