<template>
  <div>
    <Jumbo />

    <div class="container">
      <div class="row">
        <div class="col-md-12">
          <h2>Moderation</h2>
          <ModerateGramercies />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Jumbo from "@/components/Jumbo.vue";
import ModerateGramercies from "@/components/ModerateGramercies.vue";

export default {
  name: "Moderate",
  components: {
    Jumbo,
    ModerateGramercies
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
