<template>
  <div class="card">
    <div class="card-body">
      <div class="form-group">
        <label for="recipient">Recipient</label>
        <div class="input-group">
          <div class="input-group-prepend">
            <div class="input-group-text">@</div>
          </div>
          <input
            id="recipient"
            v-model="recipient"
            type="text"
            class="form-control"
            required
            max="15"
            name="recipient"
            placeholder="twitter handle"
          />
        </div>
      </div>
      <div class="form-group">
        <label for="message">Message</label>
        <textarea
          id="message"
          v-model="message"
          rows="3"
          class="form-control"
          required
          maxlength="228"
          name="message"
        ></textarea>
      </div>
    </div>
    <div class="card-footer">
      <button
        v-on:click="sendGramercy()"
        type="submit"
        class="btn btn-primary"
        value="Give Thanks"
      >Give Thanks</button>
    </div>
  </div>
</template>

<script>
const url = `https://awesum-func.azurewebsites.net/api/TweetRecorder`;

export default {
  name: "SendAnonymous",
  data: () => {
    return {
      recipient: "",
      message: "",
      isSending: false
    };
  },
  methods: {
    async sendGramercy() {
      this.isSending = true;

      const gramercy = {
        message: this.message,
        senderHandle: "",
        userMentions: [
          {
            userName: this.recipient
          }
        ]
      };

      try {
        await this.$http.post(url, gramercy, {
          "Content-Type": "application/json"
        });
        this.message = "";
        this.recipient = "";
      } catch (error) {
        /*eslint no-console: "off"*/
        console.error(error.response.data);
      } finally {
        this.isSending = false;
      }
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>