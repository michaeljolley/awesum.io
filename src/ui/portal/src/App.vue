<template>
  <div>
    <nav class="navbar navbar-light bg-light">
      <span class="navbar-brand mb-0 h1">
        <img src="./assets/images/logo.png" class="logo"/>
      </span>
      <Navigation user="null"/>
    </nav>

    <div class="container">
      <HelloWorld />
    </div>
  </div>
</template>

<script>
import HelloWorld from './components/HelloWorld.vue'
import Navigation from './components/Navigation.vue'

export default {
  name: 'app',
  components: {
    HelloWorld,
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
