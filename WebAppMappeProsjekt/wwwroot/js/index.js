$(function () {

    hentAlleDestinasjoner();
    //bestillingsVindu();
});

function hentAlleDestinasjoner() {
    let url = "rute/hentAlleDestinasjoner";
    $.get(url, function (destinasjoner) {
        visDestinasjoner(destinasjoner);
    });
}

function visDestinasjoner(destinasjoner) {
    let ut = "<select name='destinasjoner' id='selectDestinasjon' onchange='hentRuterFor()'>"
    for (let dest of destinasjoner) {
        ut += "<option value='"+dest.id+"'>" + dest.sted + "</option>";
    }

    //ut= "<button class='btn btn-primary' onclick='tilBestilling()'>Videre</button>";
    

    $("#ruteVelger").html(ut);
   
}

/*function tilBestilling() {
    window.location.href = "bestilling.html";
}*/



function hentAlleRuter() {
    let url = "rute/hentAlleRuter";
    $.get(url, function (alleRuter) {
        visRuter(alleRuter);
    });
}


function hentRuterFor() {
    
    let id = $("#selectDestinasjon").find(":selected").val();
    $("#ruteVelger").html(id);
    let url = "rute/hentMatchendeRuter?id="+id;
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



//Funksjon som prosesserer valgene fra/til og går videre til bestillingsvindu.

function bestillingsVindu() {

    let ut = "<div class='container' style='width: 50%'>" +
        "<h1>Info</h1>" +
        "<form class='form'>" +
        "<div class='form-group'>" +
        "<label>Antall Barn</label></br>" +
        "<input type='number' class='form-control' id='antallBarn'/>" +
        "<span id='feilAntallBarn' style='color: red'></span>" +
        "</div>" +
        "<div class='form-group'>" +
        "<label>Antall Voksne</label></br>" +
        "<input type='number' class='form-control' id='antallVoksen'/>" +
        "<span id='feilAntallVoksne' style='color: red'></span>" +
        "</div>" +
        "<div class='form-group'>" +
        "<label>Fornavn og Etternavn</label></br>" +
        "<input type='text' class='form-control' id='refPers'/>" +
        "<span id='feilRefPerson' style='color: red'></span>" +
        "</div>" +
        "<input type='hidden' id='avgangNr'/>" +
        "<input type='hidden' id='ruteNr'/>" +
        "<div class='form-group'>" +
        "<input type='button' id='lagre' value='Neste' onclick='lagreBestilling()' class='btn btn-primary'/>" +
        "</div>" +
        "</form>" +
        "</div>";


    $("#outputOmråde").html(ut);

    //Lagrer fra og til info midlertidig

    //Endrer html i diven for å fremvise et bestillingsform.

    //Fremviser knapp for å fullføre reservasjon av billett som kaller på lagreBestilling() 
}


//Funksjon som prosseserer valgene fra bestillingsvinduet og lagrer dem til databasen.

function lagreBestilling() {


    //Sjekker at informasjonen oppgitt i bestillingsvinduet er gyldig f.eks Simple RegEx

    //Tar informasjon ifra bestillingsvinduet og lagrer dette til bestillingsdatabasen.
    const order = {
        antallBarn: $("#antallBarn").val(),
        antallVoksen: $("#antallVoksen").val(),
        refPers: $("#refPers").val(),
        avgangNr: $("#avgangNr").val(),
        ruteNr: $("#ruteNr").val()
    }

    //Kaller på en Funksjon hentBestillinger() som henter alle bestillinger i databasen.
    const url = "Ordre/LagreOrdre";
    $.post(url, order, function () {
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
        "<th>Antall Barn</th><th>Antall Voksne</th><th>Navn</th><th>Avgang</th><th>Rute Nr</th>" +
        "</tr>";
    for (let order of ordre) {
        ut += "<tr>" +
            "<td>" + order.antallBarn + "</td>" +
            "<td>" + order.antallVoksen + "</td>" +
            "<td>" + order.refPers + "</td>" +
            "<td>" + order.avgangNr + "</td>" +
            "<td>" + order.ruteNr + "</td>" +
            "</tr>";
    }

    ut += "</table>";
    $("#outputOmråde").html(ut);
}