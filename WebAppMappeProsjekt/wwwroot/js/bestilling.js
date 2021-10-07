$(function () {
    hentAvgang();
});

function hentAvgang() {
    const id = window.location.search.substring(1);
    const url = "Rute/HentAvgang?" + id;
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
        "<input type='number' value='0' class='form-control' id='antallBarn'onChange='validerAntallBarn(this.value); hentPris()'/>" +
        "<span id='feilAntallBarn' style='color: red'></span>" +
        "</div>" +
        "<div class='form-group'>" +
        "<label>Antall Voksne (" + avganger.ruteNr.prisVoksen + " kr)</label></br>" +
        "<input type='number' value='0' class='form-control' id='antallVoksen'onChange='validerAntallVoksen(this.value);hentPris()'/>" +
        "<span id='feilAntallVoksne' style='color: red'></span>" +
        "</div>" +
        "<div class='form-group'>" +
        "<label>Fornavn og Etternavn</label></br>" +
        "<input type='text' class='form-control' id='refPers'onChange='validerNavn(this.value)'/>" +
        "<span id='feilRefPerson' style='color: red'></span>" +
        "</div>" +
        "<div class='form-group'>" +
        "<input type='hidden' class='form-control' id='avgangNr' value='" + avganger.id + "'/>" +
        "</div>" +
        "<div class='form-group'>" +
        "<input type='hidden' id='ruteNr' value='" + avganger.ruteNr.id + "'/>" +
        "</div>" +
        "<span id='pris'></span>" +
        "<div class='form-group'>" +
        "<input type='button' id='lagre' value='Bestill' onclick='validerOgLagreBestilling()' class='btn btn-default'/>" +
        "</div>" +
        "</form>" +
        "</div>";

    $("#outputOmråde").html(ut);
}

function validerOgLagreBestilling() {
    const antallBarnOK = validerAntallBarn($("#antallBarn").val());
    const antallVoksenOK = validerAntallVoksen($("#antallVoksen").val());
    const navnOK = validerNavn($("#refPers").val());

    if (antallBarnOK && antallVoksenOK && navnOK) {
        lagreBestilling();
    }
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
    $.post(url, order, function (id) {
        window.location.href = 'bestilt.html?id='+ id;

    }).fail(function () {
        $("#error").html("Feil på server! Prøv igjen senere")
    });
}

function hentPris() {
    const id = window.location.search.substring(1);
    const url = "Rute/HentAvgang?" + id;
    $.get(url, function (avganger) {
        pris(avganger);

    }).fail(function () {
        $("#error").html("Feil på server! Prøv igjen senere")
    });
}

function pris(avganger) {
    let antallBarn = $("#antallBarn").val();
    let antallVoksen = $("#antallVoksen").val();
    let totalpris = (avganger.ruteNr.prisBarn * antallBarn) + (avganger.ruteNr.prisVoksen * antallVoksen);

    if (antallBarn < 0 || antallVoksen < 0) {
        let ut = "<h3>Totalpris: 0 </h3>";
        $("#pris").html(ut);
    }
    else {
        let ut = "<h3>Totalpris: " + totalpris + "</h3>";
        $("#pris").html(ut);
    }


}