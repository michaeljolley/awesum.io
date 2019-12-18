<template>
  <div class="card pl-0 pr-0 mb-4 mr-4">
    <div class="card-body">
      <blockquote class="blockquote mb-0">
        <p>{{message}}</p>
        <footer class="blockquote-footer" v-if="!isAnonymous">
          <a v-bind:href="twitterUrl" target="_blank">{{senderHandle}}</a>
        </footer>
        <footer class="blockquote-footer" v-else>Anonymous</footer>
      </blockquote>
    </div>
    <div class="card-footer" v-if="moderate">
      <div class="row">
        <div class="col-md-6">
          <button v-on:click="save(100)" class="btn btn-primary">Approve</button>
        </div>
        <div class="col-md-6 text-right">
          <div class="btn-group">
            <button v-if="!isHeld" v-on:click="save(80)" class="btn btn-secondary">Hold</button>
            <button v-on:click="save(199)" class="btn btn-danger">Reject</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Gramercy",
  props: {
    id: String,
    message: String,
    senderHandle: String,
    status: Number,
    moderate: Boolean
  },
  computed: {
    twitterUrl: function() {
      return `https://twitter.com/${this.senderHandle}`;
    },
    isAnonymous: function() {
      return (
        !this.senderHandle || this.senderHandle.toLowerCase() == "awesumio"
      );
    },
    isHeld: function() {
      return this.status === 80;
    }
  },
  methods: {
    save: async function(status) {
      const claims = await this.$auth.getIdTokenClaims();
      const id_token = claims.__raw;

      this.$store
        .dispatch("saveGramercy", {
          id_token: id_token,
          gramercyId: this.id,
          status: status
        })
        .then(() => {
          this.$store.dispatch("loadPending", {
            id_token: id_token
          });
        })
        .then(() => {
          this.$store.dispatch("loaded");
        });
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
