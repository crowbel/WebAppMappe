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
    let ut = "<select name='destinasjoner' id='selectDestinasjon' onchange='hentRuterFor()' style='height:55px;width:600px;border-radius:5px;text-align:center;background-color:#18306E;color:white;font-weight:bold;border-color:#18306E; font-size:20px;'>" +
        "<option disabled selected value>Velg destinasjon</option>";
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
}


function hentRuterFor() {
    
    let id = $("#selectDestinasjon").find(":selected").val();
    let url = "rute/hentMatchendeRuter?id="+id;
    $.get(url, function (matchendeRuter) {
        visMatchendeRuter(matchendeRuter);
    })
}

function visMatchendeRuter(matchendeRuter) {

    let ut = "<select name='destinasjoner' id='selectRute' onchange='hentAvganger()' style='height:70px;width:300px;'><option disabled selected value> Velg rute</option>"

    for (let Rute of matchendeRuter) {

        //Test output layout for å sjekke informasjonsflyt
        ut += "<option value='" + Rute.id+"'>"+Rute.fraDestinasjon.sted+" til "+Rute.tilDestinasjon.sted +"</option>"
    }
    let iDag = new Date().toISOString().substring(0, 16);
    ut += "<input type='datetime-local' id='avreiseTid' min='" + iDag + "' style='height:70px;width:300px;'> <button onclick='hentAvganger()' style='height:70px;border-radius:5px;'>Finn reise</button>"
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

    knapp(id)
}
function formaterAvganger(avganger) {

}

function knapp(id) {
    ut = "<a class='btn btn-default' href='bestilling.html?id=" + id + "'>Videre</a>";
    $("#knapp").html(ut);
}

