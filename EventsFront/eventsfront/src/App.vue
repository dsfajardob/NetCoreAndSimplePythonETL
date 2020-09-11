<template>
  <v-app id="inspire">
    <v-navigation-drawer
      v-model="drawer"
      app
    >
      <v-list dense>
        <v-list-item link>
          <v-list-item-action>
            <v-icon>mdi-home</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Visitas</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item link>
          <v-list-item-action>
            <v-icon>mdi-email</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Registrar visita</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-app-bar
      app
      color="indigo"
      dark
    >
      <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
      <v-toolbar-title>Eventos</v-toolbar-title>
    </v-app-bar>

    
    <v-main>

       <div class="my-2">
          <v-btn @click="Alertar()" large color="primary">Get Visitors</v-btn>
        </div>

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

      <v-container 
        class="fill-height"
        fluid
      >
        <v-row
          align="center"
          justify="center"
        >
          <v-col class="text-center">
            <v-tooltip left>
              <template v-slot:activator="{ on }">
                <v-btn
                  :href="source"
                  icon
                  large
                  target="_blank"
                  v-on="on"
                >
                  <v-icon large>mdi-code-tags</v-icon>
                </v-btn>
              </template>
              <span>Source</span>
            </v-tooltip>
          </v-col>
        </v-row>
      </v-container>

    </v-main>
    <v-footer
      color="indigo"
      app
    >
      <span class="white--text">&copy; {{ new Date().getFullYear() }}</span>
    </v-footer>
  </v-app>
  
</template>

<script>
import Axios from 'axios';


window.axios = require('axios');
  function send () {
    Axios.get('https://localhost:44390/api/Visitors')
    .then((response)=> {
      console.log(response.data);
    });
  }

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
    methods: {
  Alertar: send
}
  }
</script>