<template>
  <div>
    <nav class="navbar navbar-light bg-light">
      <span class="navbar-brand mb-0 h1">
        <router-link to="/">
          <img src="./assets/images/logo.png" class="logo" />
        </router-link>
      </span>
      <Navigation />
    </nav>

    <div class="container">
      <router-view />
    </div>
  </div>
</template>

<script>
import Navigation from "./components/Navigation.vue";

export default {
  name: "app",
  components: {
    Navigation
  }
};
</script>

<style>
.logo {
  width: 250px;
  margin-top: 25px;
}
</style>
