<template>
  <div class="jumbotron jumbotron-fluid">
    <div class="container">
      <h1 class="display-4">Help. Encourage. Acknowledge.</h1>
      <div class="col-sm-12 col-md-8 col-xl-7">
        <p
          class="lead"
        >"If you want to touch the past, touch a rock. If you want to touch the present, touch a flower. If you want to touch the future, touch a life."</p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Jumbo"
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.jumbotron {
  background-color: #2a63a0;
  color: #fff;
  background-image: url("https://res.cloudinary.com/dk3rdh3yo/image/upload/v1577843174/awesumbg_anzabw.png");
  background-repeat: no-repeat;
  background-position: 80% 60%;
}

@media only screen and (max-width: 992px) {
  .jumbotron {
    background-position: 120% 60%;
  }
}
@media only screen and (max-width: 768px) {
  .jumbotron {
    background-position: 200% 60%;
  }
  .jumbotron .display-4 {
    font-size: 2.5rem;
  }
}
@media only screen and (max-width: 576px) {
  .jumbotron {
    background-image: none;
    background-position: 150% 50%;
  }
}
</style>
