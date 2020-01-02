<template>
  <div
    id="gramercyCarousel"
    class="carousel slide"
    data-ride="carousel"
    v-if="!loading"
  >
    <div class="carousel-inner">
      <div
        class="carousel-item"
        v-for="(gramercy, index) in userGramercies"
        :key="gramercy.id"
        :class="{ active: index === 0 }"
        data-interval="5000"
      >
        <Gramercy v-bind="gramercy" v-bind:moderate="false" />
      </div>
    </div>
    <a
      class="carousel-control carousel-control-prev"
      href="#gramercyCarousel"
      role="button"
      data-slide="prev"
    >
      <span class="carousel-control-prev-icon" aria-hidden="true"></span>
      <span class="sr-only">Previous</span>
    </a>
    <a
      class="carousel-control carousel-control-next"
      href="#gramercyCarousel"
      role="button"
      data-slide="next"
    >
      <span class="carousel-control-next-icon" aria-hidden="true"></span>
      <span class="sr-only">Next</span>
    </a>
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
  computed: { ...mapState(["userGramercies", "loading"]) },
  mounted: function() {}
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.carousel-control {
  color: black;
}
</style>
