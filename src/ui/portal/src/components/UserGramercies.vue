<template>
  <div>
    <div v-if="loading"></div>
    <div id="gramercyCarousel" class="carousel slide" data-ride="carousel" v-else>
      <h2>You're #awesum!</h2>

      <div v-if="userGramercies.length === 0">
        <NoGramercy />
      </div>
      <div class="carousel-inner" v-else>
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
        v-if="userGramercies.length > 0"
        class="carousel-control carousel-control-prev"
        href="#gramercyCarousel"
        role="button"
        data-slide="prev"
      >
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="sr-only">Previous</span>
      </a>
      <a
        v-if="userGramercies.length > 0"
        class="carousel-control carousel-control-next"
        href="#gramercyCarousel"
        role="button"
        data-slide="next"
      >
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="sr-only">Next</span>
      </a>
    </div>
  </div>
</template>

<script>
import Gramercy from "@/components/Gramercy.vue";
import NoGramercy from "@/components/NoGramercy.vue";
import { mapState } from "vuex";

export default {
  name: "UserGramercies",
  components: {
    Gramercy,
    NoGramercy
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
