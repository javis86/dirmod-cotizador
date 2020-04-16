<template>

  <div>    
    <h1>{{ msg }}</h1>
    <div class="sample-api">
      <h3>A continuación se listan las cotizaciones del día</h3>
      <ul class="values-list">
        <li v-for="value in values" :key="value.moneda">
          <img v-bind:src="obtenerBandera(value.moneda)" width="24" height="24">
          1 {{ value.moneda | capitalize }} - {{ value.precio }} pesos argentinos
        </li>
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
      timer: '',
      serverUrl: process.env.VUE_APP_SERVER_URL ?? 'http://localhost:5000', 
    }
  },
  created () {  
    console.log(process.env.VUE_APP_SERVER_URL);
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

        let promise1 = axios.get(this.serverUrl + '/cotizacion/dolar');
        let promise2 = axios.get(this.serverUrl + '/cotizacion/real');
        let promise3 = axios.get(this.serverUrl + '/cotizacion/euro');

        Promise.all([promise1, promise2, promise3]).then(function(responses) {
          self.values = [];

          self.values.push(responses[0].data);
          self.values.push(responses[1].data);
          self.values.push(responses[2].data);
          self.actualizando = false;
        });      
    },
    obtenerBandera(codigo){
      switch (codigo) {
        case "euro":
          return "https://image.flaticon.com/icons/svg/197/197374.svg"
        case "dolar":
          return "https://image.flaticon.com/icons/svg/197/197484.svg";
        case "real":
          return "https://image.flaticon.com/icons/svg/197/197386.svg";
      }
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
.values-list {
  margin-top: 20px !important;
}
</style>
