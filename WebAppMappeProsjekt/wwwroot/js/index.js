$(function () {
    hentAlleDestinasjoner();
});

function hentAlleDestinasjoner() {
    let url = "rute/hentAlleDestinasjoner";
    $.get(url, function (destinasjoner) {
        visDestinasjoner(destinasjoner);
    }).fail(function () {
        $("#serverErrorLabel").html("Feil på server! Prøv igjen senere");
    });
}

function visDestinasjoner(destinasjoner) {
    let ut = "<select name='destinasjoner' class='selectDestinasjon' id='selectDestinasjon' onchange='hentRuterFor()'>" +
        "<option disabled selected value=''>Velg destinasjon</option>";
    for (let dest of destinasjoner) {
        ut += "<option value='"+dest.id+"'>" + dest.sted + "</option>";
    }
    $("#fraDestinasjonVelger").html(ut); 
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
        $("#serverErrorLabel").html("Feil på server! Prøv igjen senere");
    });
}

function visMatchendeRuter(matchendeRuter) {

    let ut = "<select name='destinasjoner' id='selectRute' class='reiseSelect'><option disabled selected value> Velg rute</option>"

    for (let Rute of matchendeRuter) {
        ut += "<option value='" + Rute.id+"'>"+Rute.fraDestinasjon.sted+" til "+Rute.tilDestinasjon.sted +"</option>"
    }
    ut += "</select><p class='error' id='ruteErrorLabel'></p>"
    let iDag = new Date().toISOString().substring(0, 16);
    let datoFelt = "<input type='date' id='avreiseTid' min='" + iDag + "' class='reiseSelect'><p class='error' id='datoErrorLabel'></p> <button onclick='hentAvganger()' class='btn-search'>Finn reise</button>";
    $("#ruteVelger").html(ut)
    $("#tidspunktVelger").html(datoFelt);
}
function hentAvganger() {
    if (validerRuteValg()) {
        let id = $("#selectRute").find(":selected").val();
        let Tid = new Date($("#avreiseTid").val());
        let url = "rute/hentAvganger?ruteid=" + id + "&tid=" + Tid.toJSON();
        $.get(url, function (avganger) {
            formaterAvganger(avganger);
        }).fail(function () {
            $("#serverErrorLabel").html("Feil på server! Prøv igjen senere");
        });
        knapp(id)
    } 
}
function validerRuteValg() {
    resetErrorLabels();
    let gyldig = true;
    let id = $("#selectRute").find(":selected").val();
    let Tid = new Date($("#avreiseTid").val());
    if (!id && isNaN(Tid)) {
        $("#ruteErrorLabel").html("Du må velge en rute!");
        $("#datoErrorLabel").html("Du må velge en tid!");
        return false;
    }
    if (!id) {
        $("#ruteErrorLabel").html("Du må velge en rute!");
        return false;
    }
    if (isNaN(Tid)) {
        $("#datoErrorLabel").html("Du må velge en tid!");
        return false;
    }
    
    return gyldig;
}
function resetErrorLabels(){
    $("#ruteErrorLabel").html("");
    $("#datoErrorLabel").html("");
}

function formaterAvganger(avganger) {
    let ut = "<table class= 'table table-striped' style='width: 600px;'" +
        "<tr>" +
        "<th>Tid</th><th></th>" +
        "</tr>";
    if (avganger.length != 0) {
        for (let avgang of avganger) {
            ut += "<tr>" +
                "<td>" + avgang.avgangTid + "</td>" +
                "<td> <a class='btn btn-default' href='bestilling.html?id=" + avgang.id + "'>Velg</a> </td>" +
                "</tr>";
        }
        ut += "</table>";
        $("#ruteOutPut").html(ut);
    }
    else {
        $("#ruteOutPut").html("<p style='margin-top:30px'>Det er dessverre ingen avganger denne dagen, velg et annet tidspunkt.</p>")
    }
    
}


