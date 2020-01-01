<template>
  <footer class="footer mt-auto py-3">
    <div class="container">
      <div class="row">
        <div class="col-6">
          <span class="love">
            <a href="https://twitch.tv/BaldBeardedBuilder" target="_blank">
              <i class="fab fa-twitch"></i>
            </a>
            <i class="text-muted">Crafted with love on Twitch.</i>
          </span>
        </div>
        <div class="col-6 text-right">
          <i class="text-muted">Bug? Suggestion? Submit an issue.</i>
          <a href="https://github.com/michaeljolley/awesum.io" target="_blank">
            <i class="fab fa-github"></i>
          </a>
        </div>
      </div>
    </div>
  </footer>
</template>

<script>
export default {
  name: "SiteFooter"
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.footer {
  background-color: #f5f5f5;
}
.love {
  display: flex;
  flex-direction: row;
  align-items: center;
}
.fa-twitch,
.fa-github,
.fa-twitter,
.fa-youtube {
  font-size: 1.25em;
  color: #888888;
  margin: 0 10px;
}
.fa-youtube:hover {
  color: #e52d27;
}
.fa-github:hover {
  color: #333333;
}
.fa-twitch:hover {
  color: #6441a4;
}
.fa-twitter:hover {
  color: #55acee;
}
</style>
