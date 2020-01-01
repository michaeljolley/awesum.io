<template>
  <div>
    <Jumbo />

    <div class="container" v-if="$auth.isAuthenticated && !$auth.loading">
      <div class="row">
        <div class="col-md-12">
          <h2>Someone thinks you're #awesum!</h2>
          <UserGramercies />
        </div>
      </div>
      <hr />
    </div>

    <div class="container">
      <div class="row">
        <div class="col-4">
          <div class="card">
            <div class="card-body">
              <h4 class="card-title">What is it all about?</h4>
              <p class="card-text">Awesum.io has three goals:</p>
              <ul>
                <li>
                  <b>Help</b> those around us.
                </li>
                <li>
                  <b>Encourage</b> others to do the same.
                </li>
                <li>
                  <b>Acknowledge</b> those who do.
                </li>
              </ul>
              <p class="card-text">
                Let's face it. Whether a relative, friend, coworker or complete stranger, none of
                us would be where we are without the help of someone in our life.
              </p>
            </div>
          </div>
        </div>
        <div class="col-4">
          <div class="card">
            <div class="card-body">
              <h4 class="card-title">How does it work?</h4>
              <p class="card-text">
                First, get out there and help someone. Mentor, volunteer, or just be
                a shoulder for someone facing hardships. It all starts when each of us
                decides to invest in others.
              </p>
              <p>
                Second, encourage others to be more conscience of the needs of others
                and stand-in-the-gap for those who need help, guidance, or friendship.
              </p>
              <p>
                Third, acknowledge those who have helped you in the past. If they're on
                Twitter, then send a tweet tagging them with the #awesum hashtag. Our
                system will store that tweet so they can come back to this site and view
                all of the thanks they've received.
              </p>
              <p>
                Lastly, login above with Twitter to see any messages that have been sent to
                you. Don't worry. We don't store any data on users. Logging in simply allows
                us to query tweets sent to you.
              </p>
            </div>
          </div>
        </div>
        <div class="col-4">
          <div class="card">
            <div class="card-body">
              <h4 class="card-title">How can I help?</h4>
              <p class="card-text">There are several ways:</p>
              <ul>
                <li>
                  Acknowledge others on Twitter using the #awesum hashtag and
                  help us spread the word.
                </li>
                <li>
                  Got ideas, suggestions or bugs in the system? Submit an issue or
                  pull request on GitHub. The entire awesum.io platform is open-sourced
                  and maintained by the community.
                </li>
                <li>
                  Stop by our live-stream on
                  <a
                    href="https://twitch.tv/baldbeardedbuilder"
                    target="_blank"
                  >Twitch</a>
                  and let us know what you think!
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Jumbo from "@/components/Jumbo.vue";
import UserGramercies from "@/components/UserGramercies.vue";

export default {
  name: "Home",
  components: {
    Jumbo,
    UserGramercies
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
