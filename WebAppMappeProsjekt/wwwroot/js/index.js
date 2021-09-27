$(function () {

    hentAlleDestinasjoner();
});

function hentAlleDestinasjoner() {
    let url = "rute/hentAlleDestinasjoner";
    $.get(url, function (destinasjoner) {
        visDestinasjoner(destinasjoner);
    });
}

function visDestinasjoner(destinasjoner) {
    let ut = "<select name='destinasjoner' id='selectDestinasjon'>"
    for (let dest of destinasjoner) {
        ut += "<option value=" + dest.id + "onclick(hentRuterFor(" + dest.id + "))>" + dest.sted + "</option>";
    }
    
    $("#ruteVelger").html(ut);
}


//
function hentAlleRuter() {
    let url = "rute/hentAlleRuter";
    $.get(url, function (alleRuter) {
        visRuter(alleRuter);
    });
}


function hentRuterFor(id) {
    let url = "rute/hentMatchendeRuter";
    $.get(url, function (matchendeRuter) {
        visMatchendeRuter(matchendeRuter);
    })
}

function visMatchendeRuter(matchendeRuter) {

    let ut = "<div>"

    for (let Rute of matchendeRuter) {

        //Test output layout for å sjekke informasjonsflyt
        ut += "Id = " + Rute.id +
              "FraDestinasjon = " + Rute.fraDestinasjon.sted +
            "TilDestinasjon = " + Rute.tilDestinasjon.sted +
            "PrisBarn = " + Rute.prisBarn +
            "PrisVoksen = " + Rute.prisVoksen +
            "</div>";

    }
    $("#ruteOutPut").html(ut)
}








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
    const ordre = {
        antallBarn: $("#antallBarn"),
        antallVoksne: $("#antallVoksne"),
        refPerson: $("#refPerson"),
        avgang: $("#avgang"),
        ruteNr: $("#ruteNr")
    }

    //Kaller på en Funksjon hentBestillinger() som henter alle bestillinger i databasen.
    const url = "Ordre/LagreOrdre";
    $.post(url, ordre, function () {
        hentBestillinger();
    });

}


//Funksjon som henter alle bestillinger i databasen
function hentBestillinger() {
    //Henter alle bestillinger i databasen og viser dem i div id="outputOmråde"
    $.get("Ordre/HentAlle", function (ordre) {
        formaterOrdre(ordre);
    })
    .fail(function () {
        $("#feil").html("Feil på server - prøv igjen senere");
    });
}

function formaterOrdre(ordre) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Antall Voksne</th><th>Antall Barn</th><th>RefPerson</th><th>Avgang</th><th>Rute Nr</th>" +
        "</tr>";

    for (let order of ordre) {
        ut += "<tr>" +
            "<td>" + order.antallVoksne + "</td>" +
            "<td>" + order.antallBarn + "</td>" +
            "<td>" + order.refPerson + "</td>" +
            "<td>" + order.avgang + "</td>" +
            "<td>" + order.ruteNr + "</td>" +
            "</tr>";
    }

    ut += "</table>"
    $("#outputOmråde").html(ut);   
}