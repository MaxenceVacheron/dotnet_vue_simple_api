<template>
  <div class="FormData">
      <div class="row">
          <div class="col-5">
            <div class="bg-white pr-5 pl-5 pt-2 pb-2 rounded mt-5 ml-5 mb-5">
                <h2 class="border-bottom pb-3">Fiche de renseignement</h2>
                <div class="row mt-3">
                    <div class="col">
                        <label class="font-weight-bold">Titre</label>
                        <input v-model="title" type="text" class="form-control text-center" id="titre">
                    </div>
                    <div class="col">
                        <label class="font-weight-bold">Thèmes</label>
                        <select v-if="themeList" v-model="theme" class="form-control">
                            <option  v-for="theme in themeList" :value="theme" :key="theme">{{ theme }}</option>
                        </select>
                    </div>                    
                </div>
                <div class="row mt-3">
                    <div class="col">
                        <label class="font-weight-bold">Auteur</label>
                        <select v-if="authorList" v-model="author" class="form-control">
                            <option  v-for="item in authorList" :value="item" :key="item">{{ item }}</option>
                        </select>
                    </div>
                    <div class="col">
                        <label class="font-weight-bold">Source</label>
                        <input v-model="source" type="text" class="form-control text-center" id="Source">
                    </div>
                </div>
                <div class="row mt-3">
                    <div class="col">
                        <label class="font-weight-bold">Fichier Joints</label>
                        <input type="file" class=" text-center" id="FichierJoints">
                    </div>
                    <div class="col">
                        <label class="font-weight-bold">Images</label>
                         <input @change="onFileChange" type="file" class=" text-center" id="Images">
                    </div>
                </div>

                <div class="row text-center mt-3 border-top pt-3">
                    <div class="col">
                        <label class="font-weight-bold">Vos Commentaires</label>
                        <textarea v-model="comment" class="form-control  text-center" rows="3"></textarea>
                    </div>
                </div>

                <div class="row mt-3">
                    <div class="col">
                        <label for="indiceconfiance" class="font-weight-bold" >Indice de confiance</label>
                        <input class="ml-3" type="number" id="quantity" name="quantity" min="1" max="3">
                    </div>
                    <div class="col">
                        <label for="indiceconfiance" class="font-weight-bold">Importance de l'information</label>
                        <input class="ml-3" type="number" id="quantity" name="quantity" min="1" max="3">
                    </div>
                </div>

                <div class="row mt-3">
                    <div class="col-4">
                        <label for="birthday" class="font-weight-bold">Date</label>
                         <input v-model="date" class=" form-control" type="date" id="birthday" name="birthday">
                    </div>
                    <div class="col">
                        <label for="theme" class="font-weight-bold">Coordonnées gps</label>
                        <input v-model="gps" type="text" class="form-control" id="Inputgps" placeholder="GPS">
                    </div>
                </div>
                <button class="btn btn-dark btn-lg mt-4" onclick="location.href='http://localhost/index.html#/summary'">Sauvegarder</button>
            </div>
        </div>
          
        <div v-if="title" class="col-3 bg-white mt-5 mr-5 rounded" style="margin-left: 300px; font-family: monospace;">
            <div class="row mt-2 pb-3" style="border-width: 0 0 10px 0; border-style: solid">
                <div class="col-2">
                    <img src="../assets/drmlogo.png" width="100px" height="100px">
                </div>
                <div class="col ml-4 justify-content-center align-items-center d-flex flex-column">
                    <h5 class="font-weight-bold mt-3">Direction du Renseignement militaire</h5>
                    <p v-if="author && date" class="text-right font-italic">Rédigé par {{ author }} le {{date}}</p>
                </div>
            </div>
            <div class="row mt-2 bg-light p-2 m-2 rounded">
                <div class="col">
                    <h6 class="font-weight-bold">Sujet : {{ title }}</h6>
                </div>               
            </div>

            <div class="row mt-2 ml-2 mr-2 rounded">
                <div class="col text-left">
                    <p class="mb-0" v-if="theme && source">Le thème du document est <strong>{{ theme }}</strong> et notre source est <strong>{{ source }}</strong> </p>
                </div>               
            </div>

            <div v-if="image" class="row  ml-2 mr-2 rounded">
                <div class="col text-left">
                    <p>Voila une image correspondant à notre renseignement</p>
                </div>
            </div>

            <div class="row  ml-2 mr-2 rounded">
                <div class="col text-center">
                    <img v-if="image" :src="image" height="200px" width="200px"/>
                </div>  
                <div class="col text-center d-flex flex-column justify-content-center align-items-center">
                    <p v-if="gps">{{ gps }}</p>
                </div>               
            </div>
            <div v-if="comment" class="row  ml-2 mr-2 rounded">
                <div class="col text-left justify-content-center">
                    <p> {{ comment }} </p>
                </div>               
            </div>
        </div>
        </div>

    </div>
</template>


<script>
export default {
  name: 'FormData',
  data () {
      return {
         title: null,
         author: null,
         theme: null,
         source: null,
         comment: null,
         date: null,
         gps: null,

         image: null,
         password: null ,
         authorList: [],
         themeList: []
      }
  },
  mounted() {
    this.LoadAuthor();
    this.LoadTheme();
  },
  methods: {
      LoadAuthor() 
      {        
            this.$http
                .get('http://localhost:5000/GetUserList')
                .then(response => {
                    response.data.forEach(element => {
                        this.authorList.push(element.Username)                        
                    });
                })
                .catch(error => {
                    console.log("Erreur impossible de joindre la BDD :",error);
                })
      },
    LoadTheme() 
      {        
            this.$http
                .get('http://localhost:5000/GetAllTheme')
                .then(response => {
                    response.data.forEach(element => {
                        this.themeList.push(element.Name)                        
                    });
                })
                .catch(error => {
                    console.log("Erreur impossible de joindre la BDD :",error);
                })
      },
    onFileChange(e) {
      var files = e.target.files || e.dataTransfer.files;
      if (!files.length)
        return;
      this.createImage(files[0]);
    },
    createImage(file) {
      var reader = new FileReader();
      var vm = this;

      reader.onload = (e) => {
        vm.image = e.target.result;
      };
      reader.readAsDataURL(file);
    },
    removeImage: function () {
      this.image = null;
    }
  }
}
</script>
