$(function () {
    hentBestilling();
});

function hentBestilling() {
    const id = window.location.search.substring(1);
    const url = "Ordre/HentEn?" + id;
    $.get(url, function (order) {
        formaterOrdre(order);

    }).fail(function () {
        $("#feil").html("Feil på server - prøv igjen senere");
    });
}

function formaterOrdre(order) {

    let ut = "<h1 style='text-align:center'>Takk for din bestilling!</h1>";
    ut += "<h4 style='text-align:center;margin-top:30px'>Kvittering</h4>" +
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
        $("#outputOmråde").html(ut);
    });

}
