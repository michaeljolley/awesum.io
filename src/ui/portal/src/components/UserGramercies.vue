<template>
  <div>
    <div class="row" v-for="gramercy in gramercies" :key="gramercy.id">
      <div class="col-md-12">
        <div class="card">
          <div class="card-body">
            <blockquote class="blockquote mb-0">
              <p>{{gramercy.message}}</p>
              <footer class="blockquote-footer">{{gramercy.senderHandle}}</footer>
            </blockquote>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapState } from "vuex";

export default {
  name: "UserGramercies",
  computed: { ...mapState(["gramercies"]) }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
