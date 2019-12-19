<template>
  <div>
    <div class="container-fluid bg-white ml-0 mr-0 pl-0 pr-0">
      <div class="container ml-0 mr-0 pl-0 pr-0 mr-md-auto ml-md-auto">
        <nav class="navbar navbar-light">
          <span class="navbar-brand mb-0 h1">
            <router-link to="/">
              <img src="./assets/images/logo-full.png" class="logo" />
            </router-link>
          </span>
          <Navigation />
        </nav>
      </div>
    </div>

    <router-view />
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
}

.bg-white {
  background: #fff;
}

.btn-primary,
.btn-primary.disabled,
.btn-primary:hover,
.btn-primary:not(:disabled):not(.disabled):active {
  background-color: #0ac9af;
  border-color: #0ac9af;
  font-weight: bold;
}
.btn-primary:not(:disabled):not(.disabled):active:focus {
  box-shadow: rgba(10, 201, 175, 0.5);
}
</style>
