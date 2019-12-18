<template>
  <div>
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
<style scoped></style>
