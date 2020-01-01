<template>
  <header>
    <div class="container-fluid bg-white ml-0 mr-0 pl-0 pr-0">
      <div class="container ml-0 mr-0 pl-0 pr-0 mr-md-auto ml-md-auto">
        <nav class="navbar navbar-light">
          <span class="navbar-brand mb-0 h1">
            <router-link to="/">
              <img src="../assets/images/logo-full.png" class="logo" />
            </router-link>
          </span>
          <Navigation />
        </nav>
      </div>
    </div>
  </header>
</template>

<script>
import Navigation from "./Navigation.vue";

export default {
  name: "SiteHeader",
  components: {
    Navigation
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.logo {
  width: 250px;
}

.user-picture {
  width: 36px;
}
</style>
