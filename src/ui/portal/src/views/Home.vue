<template>
  <div>
    <div class="jumbotron jumbotron-fluid">
      <div class="container">
        <h1 class="display-4">Welcome!</h1>
        <p
          class="lead"
        >This is a modified jumbotron that occupies the entire horizontal space of its parent.</p>
      </div>
    </div>

    <div class="container">
      <div class="row">
        <div class="col-md-12">
          <h2>Home</h2>
          <div v-if="!$auth.isAuthenticated && !$auth.loading">
            <p>Who dat?</p>
          </div>
          <div v-else>
            <UserGramercies />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import UserGramercies from "@/components/UserGramercies.vue";

export default {
  name: "Home",
  components: {
    UserGramercies
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.jumbotron {
  background-color: #0071bc;
  color: #fff;
}
</style>
