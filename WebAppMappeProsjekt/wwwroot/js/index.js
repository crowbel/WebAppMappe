﻿$(function () {

    // Kall på funksjon som danner hovedutseende til bestillingsløsningen.

});


//Funksjon som fremviser fra/til rutevelger 
function ruteVelger() {

    //Fremviser 2 dropdown menyer i div med id="outputOmråde"

    //En med FRA destinasjoner og en med TIL destinasjoner

    //Fremviser knapp for å trykke videre til bestillingsVindu()
}


//Funksjon som prosesserer valgene fra/til og går videre til bestillingsvindu.
function bestillingsVindu() {

    //Lagrer fra og til info midlertidig

    //Endrer html i diven for å fremvise et bestillingsform.

    //Fremviser knapp for å fullføre reservasjon av billett som kaller på lagreBestilling() 
}


//Funksjon som prosseserer valgene fra bestillingsvinduet og lagrer dem til databasen.
function lagreBestilling() {

    //Sjekker at informasjonen oppgitt i bestillingsvinduet er gyldig f.eks Simple RegEx

    //Tar informasjon ifra bestillingsvinduet og lagrer dette til bestillingsdatabasen.

    //Kaller på en Funksjon hentBestillinger() som henter alle bestillinger i databasen.

}


//Funksjon som henter alle bestillinger i databasen
function hentBestillinger() {
    //Henter alle bestillinger i databasen og viser dem i div id="outputOmråde"
}