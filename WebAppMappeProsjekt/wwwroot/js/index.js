$(function () {
    hentAlleDestinasjoner();
});

function hentAlleDestinasjoner() {
    let url = "rute/hentAlleDestinasjoner";
    $.get(url, function (destinasjoner) {
        visDestinasjoner(destinasjoner);
    }).fail(function () {
        $("#ruteVelgerErrorField").html("Feil på server! Prøv igjen senere");
    });
}

function visDestinasjoner(destinasjoner) {
    let ut = "<select name='destinasjoner' class='selectDestinasjon' id='selectDestinasjon' onchange='hentRuterFor()' style='height:55px;width:600px;border-radius:5px;text-align:center;background-color:#18306E;color:white;font-weight:bold;border-color:#18306E; font-size:20px;'>" +
        "<option disabled selected value=''>Velg destinasjon</option>";
    for (let dest of destinasjoner) {
        ut += "<option value='"+dest.id+"'>" + dest.sted + "</option>";
    }
    $("#ruteVelger").html(ut); 
}


function hentAlleRuter() {
    let url = "rute/hentAlleRuter";
    $.get(url, function (alleRuter) {
        visRuter(alleRuter);
    });
    //Brukes denne?
}


function hentRuterFor() {
    
    let id = $("#selectDestinasjon").find(":selected").val();
    let url = "rute/hentMatchendeRuter?id="+id;
    $.get(url, function (matchendeRuter) {
        visMatchendeRuter(matchendeRuter);
    }).fail(function () {
        $("#ruteVelgerErrorField").html("Feil på server! Prøv igjen senere");
    });
}

function visMatchendeRuter(matchendeRuter) {

    let ut = "<select name='destinasjoner' id='selectRute' style='height:70px;width:300px;'><option disabled selected value> Velg rute</option>"

    for (let Rute of matchendeRuter) {

        //Test output layout for å sjekke informasjonsflyt
        ut += "<option value='" + Rute.id+"'>"+Rute.fraDestinasjon.sted+" til "+Rute.tilDestinasjon.sted +"</option>"
    }
    let iDag = new Date().toISOString().substring(0, 16);
    ut += "<input type='datetime-local' id='avreiseTid' min='" + iDag + "' style='height:70px;width:300px;'>";
    ut += "<button  style ='height:70px;border-radius:5px;' onclick = 'hentAvganger()'>Finn reise</button >";
    $("#ruteOutPut").html(ut)
}
function hentAvganger() {
    if (validerRuteValg()) {
        let id = $("#selectRute").find(":selected").val();
        let Tid = new Date($("#avreiseTid").val());
        let url = "rute/hentAvganger?ruteid=" + id + "&tid=" + Tid.toJSON();
        $.get(url, function (avganger) {
            formaterAvganger(avganger);
        }).fail(function () {
            $("#ruteVelgerErrorField").html("Feil på server! Prøv igjen senere");
        });
    } else {
        $("#ruteVelgerErrorField").html("Ett eller flere felt er ugyldige!");
    }
}
function validerRuteValg() {
    let gyldig = true;
    let id = $("#selectRute").find(":selected").val();
    let Tid = new Date($("#avreiseTid").val());
    if (!id) {
        //TODO lage egne felt for hver meny
        $("#ruteVelgerErrorField").html("Du må velge en rute!");
    }
    if (isNaN(Tid)) {
        $("#ruteVelgerErrorField").html("Du må velge en tid!");
    }
    return gyldig;
}
function formaterAvganger(avganger) {
    let ut = "<table class= 'table table-striped' style='width: 600px;'" +
        "<tr>" +
        "<th>Tid</th><th></th>" +
        "</tr>";
    for (let avgang of avganger) {
        ut += "<tr>" +
            "<td>" + avgang.avgangTid + "</td>" +
            "<td> <a class='btn btn-default' href='bestilling.html?id=" + avgang.id + "'>Velg</a> </td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#ruteOutPut").html(ut);
}


