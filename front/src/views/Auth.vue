<template>
  <div class="d-flex flex-column min-vh-100 justify-content-center align-items-center">
    <div class="bg-white pr-5 pl-5 pt-2 pb-2 rounded">
        <img src="../assets/logoMDR.png" width="100px" height="100px">
            <h4 class="text-dark">Authentification de l'utilisateur</h4>
            <div class="form-group">
                <label>Identification</label>
                <input id="username" v-model="username" name="username" type="text" class="form-control form-control-lg text-center"/>
            </div>
             <div class="form-group">
                <label>Mot de passe</label>
                <input id="password" v-model="password" name="password" type="password" class="form-control form-control-lg text-center"/>
            </div>
            <button v-on:click="CheckUser()" class="btn btn-dark btn-lg mt-2">S'identifier</button>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Auth',
  data () {
      return {
         username: null,
         password: null 
      }
  },
    methods: {
        CheckUser: function () {
            this.$http
                .get('http://localhost:5000/CheckUserExist?username='+this.username+'&password='+this.password)
                .then(response => {
                    if (response.data)
                    {
                        this.$router.push("FormData");
                    } 
                    else
                    {
                        this.$router.push("Auth");
                    }
                })
                .catch(error => {
                    console.log("Erreur impossible de joindre la BDD :",error);
                })
        }
    }
}
</script>
