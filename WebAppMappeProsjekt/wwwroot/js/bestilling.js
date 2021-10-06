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

    }).fail(function () {
        $("#error").html("Feil på server! Prøv igjen senere")
    });
}





function bestillingsVindu(avganger) {

    let ut = "<div class='container'>" +
        "<h1>Info</h1>" +
        "<form class='form'>" +
        "<div class='form-group'>" +
        "<label>Antall Barn (" + avganger.ruteNr.prisBarn + " kr)</label></br > " +
        "<input type='number' class='form-control' id='antallBarn'onChange='resetErrors()'/>" +
        "<span id='feilAntallBarn' style='color: red'></span>" +
        "</div>" +
        "<div class='form-group'>" +
        "<label>Antall Voksne (" + avganger.ruteNr.prisVoksen + " kr)</label></br>" +
        "<label id='antallVoksneErr'></label></br>" +
        "<input type='number' class='form-control' id='antallVoksen'onChange='resetErrors()'/>" +
        "<span id='feilAntallVoksne' style='color: red'></span>" +
        "</div>" +
        "<div class='form-group'>" +
        "<label>Fornavn og Etternavn</label></br>" +
        "<input type='text' class='form-control' id='refPers'onChange='resetErrors()'/>" +
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
   // console.log(avganger.avgangTid);
    //$("#avgang").html(avganger.avgangTid);

    //Sjekker at informasjonen oppgitt i bestillingsvinduet er gyldig f.eks Simple RegEx

    if (validate()) {
    const order = {
        antallBarn: $("#antallBarn").val(),
        antallVoksen: $("#antallVoksen").val(),
        refPers: $("#refPers").val(),
        avgangNr: $("#avgangNr").val(),
        ruteNr: $("#ruteNr").val()
    }
    const url = "Ordre/LagreOrdre";
    $.post(url, order, function (id) {
        hentBestilling(id)

        
    }).fail(function () {
        $("#error").html("Feil på server! Prøv igjen senere")
    });
    }
}
function validate() {
    let gyldig = true;
    let antallBarn = $("#antallBarn").val();
    let antallVoksne = $("#antallVoksen").val();
    let totalAntall = antallBarn + antallVoksne;
    if (totalAntall < 1) {
        gyldig = false;
        $("#feilAntallVoksne").html("Billetten må gjelde minst 1 person!");
    }
    if (!$("#refPers").val()) {
        gyldig = false;
        $("#feilRefPerson").html("Du må oppgi et navn!");
    }
    return gyldig;
}
function resetErrors() {
    $("#feilRefPerson").html("");
    $("#feilAntallVoksne").html("");
}



function hentBestilling(id) {
    $.get("Ordre/HentEn?id="+id, function (order) {
        formaterOrdre(order);
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
        "<th>Antall Barn</th><th>Antall Voksne</th><th>Navn</th><th>Avgang</th><th>Rute</th><th>Sum</th>" +
        "</tr>";
    
    ut += "<tr>" +
        "<td>" + order.antallBarn + "</td>" +
        "<td>" + order.antallVoksen + "</td>" +
        "<td>" + order.refPers + "</td>";
        
    
    $.get("rute/hentAvgang?id=" + order.avgangNr, function (avgang) {
        let avreiseTid = new Date(avgang.avgangTid);
        let totalsum = (order.antallBarn * avgang.ruteNr.prisBarn) + (order.antallVoksen * avgang.ruteNr.prisVoksen);
        ut += "<td>" + avreiseTid.toLocaleString() + "</td>" +
            "<td>" + avgang.ruteNr.fraDestinasjon.sted + " til " + avgang.ruteNr.tilDestinasjon.sted + "</td>" +
            "<td>" + totalsum + " kr</td>";
        ut += "</tr ></table>";
        ut += "<input type='button' id='checkout' Value='Bestill' onclick='bestill()' class='btn btn-default'/>";
        $("#outputOmråde").html(ut);
    });


}