<template>
  <div class="d-flex flex-column h-100">
    <SiteHeader />

    <main role="main" class="flex-shrink-0">
      <router-view />
    </main>

    <SiteFooter />
  </div>
</template>

<script>
import SiteFooter from "./components/SiteFooter.vue";
import SiteHeader from "./components/SiteHeader.vue";

export default {
  name: "app",
  components: {
    SiteFooter,
    SiteHeader
  }
};
</script>

<style>
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
