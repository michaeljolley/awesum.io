<template>
  <div class="row">
    <Gramercy
      v-for="gramercy in userGramercies"
      :key="gramercy.id"
      v-bind="gramercy"
      v-bind:moderate="false"
      class="col-md-5"
    />
  </div>
</template>

<script>
import Gramercy from "@/components/Gramercy.vue";
import { mapState } from "vuex";

export default {
  name: "UserGramercies",
  components: {
    Gramercy
  },
  computed: { ...mapState(["userGramercies"]) }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
