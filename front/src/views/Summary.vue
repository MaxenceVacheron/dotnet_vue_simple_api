<template>
  <div class="hello">
    <h1>Dashboard</h1>

    <div id="infoDisplay" class="modal">
      <!-- Modal content -->
      <div class="modal-content">
        <span class="close">&times;</span>
        <div id="Title"></div>
        <div id="Author"></div>
        <div id="Source"></div>
        <div id="Audio_Path"></div>
        <div id="Comment"></div>
        <div id="Date"></div>
        <div id="Gps_Coordinates"></div>
        <div id="Level"></div>
        <div id="ReliabilityLevel"></div>
        <div id="Theme"></div>
      </div>
    </div>
    <ul class="ul-container">
      <li
        v-for="intel in intels"
        :key="intel.Id"
        :id="intel.Id"
        @click="openInfo(intel.Id)"
      >
        <div class="li-col li-col-1">
          <div><b>Titre : {{ intel.Title }}</b></div>
          <div>Auteur : {{ intel.Author }}</div>
          <div>Source : {{ intel.Source }}</div>
        </div>
        <div class="li-col li-col-2">
          <span>Date : {{ intel.Date }}</span>
          <span>Level : {{ intel.Level }}</span>
          <span>Theme : {{ intel.Theme }}</span>
          <span>ID : {{ intel.Id }}</span>
        </div>
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  name: "Sumary",
  data() {
    return {
      intels: [],
    };
  },
  mounted() {
    this.$http
      .get("http://localhost:5000/getInformations")
      .then((response) => {
        console.log("GetInformations :", response.data);
        this.intels = response.data;
      })
      .catch((error) => {
        console.log("Erreur impossible de joindre la BDD :", error);
      });
    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
      if (event.target == document.getElementById("infoDisplay")) {
        document.getElementById("infoDisplay").style.display = "none";
      }
    };
  },
  methods: {
    openInfo: function (intelID) {
      this.intels.forEach((intel) => {
        if (intel.Id == intelID) {
          this.fillAndDisplayIntel(intel);
        }
      });
    },
    fillAndDisplayIntel: function (intel) {
      console.log(intel);
      document.getElementById("infoDisplay").style.display = "block";

      document.getElementById("Audio_Path").innerHTML = (intel.Audio_Path === '') ? 'Fichier : Vide' : '<b>Fichier</b> : <img width="50%" src="/' + intel.Audio_Path + '" v-bind:alt="pic">';
      document.getElementById("Author").innerHTML = (intel.Author === '') ? 'Auteur : Vide' : '<b>Auteur : </b>' + intel.Author;
      document.getElementById("Comment").innerHTML = (intel.Comment === '') ? 'Commentaire : Vide' : '<b>Commentaire : </b>' + intel.Comment;
      document.getElementById("Date").innerHTML = (intel.Date === '') ? 'Date : Vide' : '<b>Date : </b>' + intel.Date;
      document.getElementById("Gps_Coordinates").innerHTML = (intel.Gps_Coordinates === '') ? 'GPS : Vide' : '<b>GPS : </b>' + intel.Gps_Coordinates;
      document.getElementById("Level").innerHTML = (intel.Level === '') ? 'Niveau : Vide' : '<b>Niveau : </b>' + intel.Level;
      document.getElementById("ReliabilityLevel").innerHTML = (intel.ReliabilityLevel === '') ? 'Fiabilité : Vide' : '<b>Fiabilité : </b>' +  intel.ReliabilityLevel;
      document.getElementById("Source").innerHTML = (intel.Source === '') ? 'Source :Vide' : '<b>Source : </b>' + intel.Source;
      document.getElementById("Theme").innerHTML = (intel.Theme === '') ? 'Theme : Vide' : '<b>Theme : </b>' + intel.Theme;
      document.getElementById("Title").innerHTML = (intel.Title === '') ? 'Titre : Vide' : '<b>Titre : ' + intel.Title + '</b>';

      document.getElementsByClassName("close")[0].onclick = function () {
        document.getElementById("infoDisplay").style.display = "none";
      };
    },
}
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1,
h2 {
  font-weight: normal;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}

#infoDispay {
  display: none;
}

.ul-container {
  display: flex;
  flex-flow: column nowrap;
}

.ul-container > li {
  border-radius: 10px;
  width: 70%;
  background-color: darkgray;
  border: 1px solid green;
  display: flex;
  flex-flow: row nowrap;
  justify-content: space-around;
  padding: 1em;
  margin: 1em;
}

.li-col {
  border-radius: 10px;
  display: flex;
  flex-flow: column nowrap;
}

/* The Modal (background) */
.modal {
  display: none; /* Hidden by default */
  position: fixed; /* Stay in place */
  z-index: 1; /* Sit on top */
  left: 0;
  top: 0;
  width: 100%; /* Full width */
  height: 100%; /* Full height */
  overflow: auto; /* Enable scroll if needed */
  background-color: rgb(0, 0, 0); /* Fallback color */
  background-color: rgba(0, 0, 0, 0.4); /* Black w/ opacity */
}

/* Modal Content/Box */
.modal-content {
  background-color: #fefefe;
  margin: 15% auto; /* 15% from the top and centered */
  padding: 20px;
  border: 1px solid #888;
  width: 80%; /* Could be more or less, depending on screen size */
  display:flex;
  flex-flow:column nowrap;
  align-items: flex-start

}

/* The Close Button */
.close {
  color: #aaa;
  float: right;
  font-size: 28px;
  font-weight: bold;
}

.close:hover,
.close:focus {
  color: black;
  text-decoration: none;
  cursor: pointer;
}

img {
  width:500px;
}

	* {
		-webkit-transition: all 0.2s ease;
		-moz-transition: all 0.2s ease;
		-ms-transition: all 0.2s ease;
		-o-transition: all 0.2s ease;
		transition: all 0.2s ease;
		-webkit-tap-highlight-color: rgba(0, 0, 0, 0);

	}
</style>
