<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <div class="sample-api">
      <h3>A continuación se listan las cotizaciones del dìa</h3>
      <ul class="values-list">
        <li v-for="value in values" :key="value.moneda">{{ value.moneda | capitalize }} - {{ value.precio }}</li>
      </ul>
      <div v-if="actualizando == true">
        Actualizando las cotizaciones...
      </div>

    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'HelloWorld',
  props: {
    msg: String
  },
  data () {
    return {
      values: [],
      actualizando: false,
      timer: ''
    }
  },
  created () {
    // Send request to the ASP.NET Core application.
    // Either send request to https://localhost:5001/api/values or setup vue dev proxy and send it to /api/values
    this.actualizarCotizaciones();
    this.timer = setInterval(this.actualizarCotizaciones, 5000)
  },
  beforeDestroy () {
      clearInterval(this.timer);
  },
  filters: {
    capitalize: function (value) {
      if (!value) return ''
      value = value.toString()
      return value.charAt(0).toUpperCase() + value.slice(1)
    }
  },
  methods: {
    actualizarCotizaciones(){
        this.actualizando = true;
        let self = this;

        let promise1 = axios.get('http://localhost:5000/cotizacion/dolar');
        let promise2 = axios.get('http://localhost:5000/cotizacion/real');
        let promise3 = axios.get('http://localhost:5000/cotizacion/euro');

        Promise.all([promise1, promise2, promise3]).then(function(responses) {
          self.values = [];

          self.values.push(responses[0].data);
          self.values.push(responses[1].data);
          self.values.push(responses[2].data);
          self.actualizando = false;
        });      
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
