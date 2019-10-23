<template>
  <div>
    <nav class="navbar navbar-light bg-light">
      <span class="navbar-brand mb-0 h1">
        <img src="./assets/images/logo.png" class="logo"/>
      </span>
      <Navigation/>
    </nav>

    <div class="container">
      <router-view />
    </div>
  </div>
</template>

<script>
import Navigation from './components/Navigation.vue'

export default {
  name: 'app',
  components: {
    Navigation
  }
}
</script>

<style>
  .logo {
    width: 250px;
    margin-top: 25px;
  }
</style>
