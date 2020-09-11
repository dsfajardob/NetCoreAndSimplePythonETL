<template>
  <div class="about">
  <div id="app">
    <v-app id="inspire">
      <v-data-table
        :headers="headers"
        :items="desserts"
        :items-per-page="5"
        class="elevation-1"
      ></v-data-table>
    </v-app>
  </div>

  </div>  
</template>


<script>
import Axios from 'axios';

  export default {
    props: {
      source: String,
    },
    data: () => ({
      drawer: null,
      headers: [
        {
          text: 'CC',
          align: 'start',
          sortable: false,
          value: 'cedula',
        },
        { text: 'Email', value: 'email' },
        { text: 'Nombre', value: 'nombres' },
        { text: 'Telofono', value: 'telefono' },
      ],
      desserts: []
      
    }),
    created(){
        Axios.get('https://localhost:44390/api/Visitors')
    .then((response)=> {
      console.log(response.data);
      this.desserts = response.data;
    });
      },
  }
</script>
