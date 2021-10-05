$(function () {
    /*const id = window.location.search.substring(1);
    const url = "Rute/HentEnAvgang?" + id;
    $.get(url, function (avganger) {
        lagreBestilling(avganger);
    });
    bestillingsVindu();*/
    hentAvgang();
    
    
});

function hentAvgang() {
    const id = window.location.search.substring(1);
    const url = "Rute/HentEnAvgang?"+id;
    $.get(url, function (avganger) {
        bestillingsVindu(avganger);

    });
}





function bestillingsVindu(avganger) {

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
        "<div class='form-group'>" +
        "<input type='hidden' class='form-control' id='avgangNr' value='" + avganger.id + "'/>" +
        "</div>"+
        "<div class='form-group'>" +
        "<input type='hidden' id='ruteNr' value='"+avganger.ruteNr.id+"'/>" +  
        "</div>" +
        "<div class='form-group'>" +
        "<input type='button' id='lagre' value='Neste' onclick='lagreBestilling()' class='btn btn-default'/>" +
        "</div>" +
        "</form>" +
        "</div>";


    $("#outputOmråde").html(ut);

    //Lagrer fra og til info midlertidig

    
}



function lagreBestilling() {
    /*console.log(avganger.avgangTid);
    $("#avgang").html(avganger.avgangTid);*/

    //Sjekker at informasjonen oppgitt i bestillingsvinduet er gyldig f.eks Simple RegEx

    
    const order = {
        antallBarn: $("#antallBarn").val(),
        antallVoksen: $("#antallVoksen").val(),
        refPers: $("#refPers").val(),
        avgangNr: $("#avgangNr").val(),
        ruteNr: $("#ruteNr").val()
    }

    //Kaller på en Funksjon hentBestillinger() som henter alle bestillinger i databasen.

    

    const url = "Ordre/LagreOrdre";
    $.post(url, order, function (id) {
        hentBestilling(id)

        
    });
}



function hentBestilling(id) {
    $.get("Ordre/HentEn?id="+id, function (order) {
        //formaterOrdre(order);
        console.log(order.avgangNr);

    })
        .fail(function () {
            $("#feil").html("Feil på server - prøv igjen senere");
        });
}

function formaterOrdre(order) {
    let ut = "<h1 style='text-align:center'>Bestillingsoversikt</h1>" +
        "<table class='table table-striped' >" +
        "<tr>" +
        "<th>Antall Barn</th><th>Antall Voksne</th><th>Navn</th><th>Avgang</th><th>Rute</th>" +
        "</tr>";
    
    ut += "<tr>" +
        "<td>" + order.antallBarn + "</td>" +
        "<td>" + order.antallVoksen + "</td>" +
        "<td>" + order.refPers + "</td>" +
        "<td>" + order.avgangNr + "</td>" +
        "<td>" + order.ruteNr + "</td>" +
        "</tr>";

    ut += "</table>";
    ut += "<input type='button' id='checkout' Value='Bestill' onclick='bestill()' class='btn btn-default'/>";
    $("#outputOmråde").html(ut);
}