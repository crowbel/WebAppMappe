$(function () {

    hentAlleDestinasjoner();
    knapp();
});

function hentAlleDestinasjoner() {
    let url = "rute/hentAlleDestinasjoner";
    $.get(url, function (destinasjoner) {
        visDestinasjoner(destinasjoner);
    });
}

function visDestinasjoner(destinasjoner) {
    let ut = "<select name='destinasjoner' id='selectDestinasjon' onchange='hentRuterFor()' style='height:50px;width:300px;'>" +
        "<option disabled selected value>Velg destinasjon</option>";
    for (let dest of destinasjoner) {
        ut += "<option value='"+dest.id+"'>" + dest.sted + "</option>";
    }
    
    $("#ruteVelger").html(ut);
   
}

function knapp() {
    ut = "<button class='btn btn-default' onclick='tilBestilling()'>Videre</button>";
    $("#knapp").html(ut);
}

function tilBestilling() {
    window.location.href = "bestilling.html";
}



function hentAlleRuter() {
    let url = "rute/hentAlleRuter";
    $.get(url, function (alleRuter) {
        visRuter(alleRuter);
    });
}


function hentRuterFor() {
    
    let id = $("#selectDestinasjon").find(":selected").val();
    let url = "rute/hentMatchendeRuter?id="+id;
    $.get(url, function (matchendeRuter) {
        visMatchendeRuter(matchendeRuter);
    })
}

function visMatchendeRuter(matchendeRuter) {

    let ut = "<select name='destinasjoner' id='selectRute' onchange='hentAvganger()'><option disabled selected value> Velg rute</option>"

    for (let Rute of matchendeRuter) {

        //Test output layout for å sjekke informasjonsflyt
        ut += "<option value='" + Rute.id+"'>"+Rute.fraDestinasjon.sted+" til "+Rute.tilDestinasjon.sted +"</option>"

    }
    ut+= "<input type='datetime-local' id='avreiseTid'> <button onclick='hentAvganger()'>Finn reise</button>"
    $("#ruteOutPut").html(ut)
}
function hentAvganger() {
    
    let id = $("#selectRute").find(":selected").val();
    let Tid = new Date($("#avreiseTid").val());
    let url = "rute/hentAvganger?ruteid=" + id + "&tid=" + Tid.toJSON();
    $.get(url, function (avganger) {
        formaterAvganger(avganger);
    });
    $("#ruteOutput").html(id);
}
function formaterAvganger(avganger) {

}

//Funksjon som prosesserer valgene fra/til og går videre til bestillingsvindu.

/*function bestillingsVindu() {

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

    
}



function lagreBestilling() {


    
    const order = {
        antallBarn: $("#antallBarn").val(),
        antallVoksen: $("#antallVoksen").val(),
        refPers: $("#refPers").val(),
        avgangNr: $("#avgangNr").val(),
        ruteNr: $("#ruteNr").val()
    }

   
    const url = "Ordre/LagreOrdre";
    $.post(url, order, function () {
        hentBestillinger();
    });

}



function hentBestillinger() {
    
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
}*/