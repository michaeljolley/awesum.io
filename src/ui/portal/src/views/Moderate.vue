<template>
  <div>
    <div class="row">
      <div class="col-md-12">
        <h2>Moderate</h2>
        <ModerateGramercies />
      </div>
    </div>
  </div>
</template>

<script>
import ModerateGramercies from "@/components/ModerateGramercies.vue";

export default {
  name: "Moderate",
  components: {
    ModerateGramercies
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
