<template>
<div id="app">
  <v-app id="inspire">
    <v-form v-model="valid">
      <v-container>
        <v-row>
          <v-col
            cols="12"
            md="4"
          >
            <v-text-field
              label="Cedula"
              v-model="Cedula"
              required
            ></v-text-field>
          </v-col>
  
          <v-col
            cols="12"
            md="4"
          >
            <v-text-field
              label="Nombre"
              v-model="Nombre"
              required
            ></v-text-field>
          </v-col>
  
          <v-col
            cols="12"
            md="4"
          >
            <v-text-field
              label="Telefono"
              v-model="Telefono"
              required
            ></v-text-field>
          </v-col>
          
          <v-col
            cols="12"
            md="4"
          >
            <v-text-field
              label="Email"
              v-model="Email"
              required
            ></v-text-field>
          </v-col>
        </v-row>
      </v-container>
      
    </v-form>    
       <div class="my-2">
          <v-btn @click="Submit" large color="primary">Registrarse</v-btn>
        </div>
  </v-app>
  
</div>
</template>

<script>
import Axios from 'axios';


window.axios = require('axios');
  /*function send () {
    alert("Done");
    Axios.get('https://localhost:44390/api/Visitors')
    .then((response)=> {
      console.log(response.data);
    });
  }*/

  export default {
    props: {
      source: String,
    },
    data(){
      return {
        Cedula: '',
        Nombre: '',
        Telefono: '',
        Email: '',

      }
    },
    methods: {

  Submit () {
    
      const config = {
      headers: {
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Methods': 'GET, PUT, POST, DELETE, OPTIONS',
        'Content-Type': 'application/json',
        }
      };

      const data = {
      Nombre: this.Nombre,
      Telefono: this.Telefono,
      Cedula: this.Cedula,
      Email: this.Email
      };

    Axios.post('https://localhost:44390/api/Visitors'
    ,data,config)
    .then((response)=> {
      console.log(response.data);
    });
  }
}
  }
</script>

