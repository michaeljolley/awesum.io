<template>
  <div class="row">
    <Gramercy
      v-for="gramercy in pendingGramercies"
      :key="gramercy.id"
      v-bind="gramercy"
      v-bind:moderate="true"
      class="col-md-5"
    />
  </div>
</template>

<script>
import Gramercy from "@/components/Gramercy.vue";
import { mapState } from "vuex";

export default {
  name: "ModerateGramercies",
  components: {
    Gramercy
  },
  computed: { ...mapState(["pendingGramercies"]) },
  created: async function() {
    const claims = await this.$auth.getIdTokenClaims();
    const id_token = claims.__raw;
    this.$store
      .dispatch("loadPending", {
        id_token: id_token
      })
      .then(() => {
        this.$store.dispatch("loaded");
      });
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
