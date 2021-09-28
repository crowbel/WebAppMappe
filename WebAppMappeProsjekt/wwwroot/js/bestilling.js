$(function () {

    bestillingsVindu();
});

function bestillingsVindu() {

    let ut = "<div class='container'>" +
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
        "<input type='button' id='lagre' value='Neste' onclick='lagreBestilling()' class='btn'/>" +
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
    let ut ="<h1 style='text-align:center'>Bestillingsoversikt</h1>"+
        "<table class='table table-striped'>" +
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