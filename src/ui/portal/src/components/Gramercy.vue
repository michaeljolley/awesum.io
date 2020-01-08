<template>
  <div class="card pl-0 pr-0 mb-4 mr-md-4">
    <div class="card-body">
      <blockquote class="blockquote mb-0">
        <p>{{message}}</p>
        <footer class="blockquote-footer" v-if="!isAnonymous">
          <a v-bind:href="senderTwitterUrl" target="_blank">{{senderHandle}}</a>
        </footer>
        <footer class="blockquote-footer" v-else>Anonymous</footer>
         for <a v-bind:href="recipientTwitterUrl" target="_blank">{{recipientHandle}}</a>
      </blockquote>
    </div>
    <div class="card-footer" v-if="moderate">
      <div class="row">
        <div class="col-6">
          <button v-on:click="save(100)" v-bind:disabled="loading" class="btn btn-primary">Approve</button>
        </div>
        <div class="col-6 text-right">
          <div class="btn-group">
            <button
              v-if="!isHeld"
              v-bind:disabled="loading"
              v-on:click="save(80)"
              class="btn btn-secondary"
            >Hold</button>
            <button v-on:click="save(199)" v-bind:disabled="loading" class="btn btn-danger">Reject</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapState } from "vuex";

export default {
  name: "Gramercy",
  props: {
    id: String,
    message: String,
    senderHandle: String,
    recipientHandle: String,
    status: Number,
    moderate: Boolean
  },
  computed: {
    ...mapState(["loading"]),
    senderTwitterUrl: function() {
      return `https://twitter.com/${this.senderHandle}`;
    },
    recipientTwitterUrl: function() {
      return `https://twitter.com/${this.recipientHandle}`;
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
.btn-secondary,
.btn-secondary.disabled,
.btn-secondary:hover,
.btn-secondary.active {
  background-color: #babcbd;
  border-color: #babcbd;
}
.btn-secondary:focus {
  box-shadow: rgba(186, 188, 189, 0.5);
}

.btn-danger,
.btn-danger.disabled,
.btn-danger:hover,
.btn-danger.active {
  background-color: #f15a24;
  border-color: #f15a24;
}
.btn-danger:focus {
  box-shadow: rgba(241, 90, 36, 0.5);
}
</style>
