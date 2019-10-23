<template>
  <div>
    <div class="row">
      <div class="col-md-3">
        <SendAnonymous />
      </div>
      <div class="col-md-9">
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
import SendAnonymous from "@/components/SendAnonymous.vue";
import UserGramercies from "@/components/UserGramercies.vue";

export default {
  name: "Home",
  components: {
    SendAnonymous,
    UserGramercies
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped></style>
