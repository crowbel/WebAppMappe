function validerAntallBarn(antallBarn) {
    const regexp = /^[0-9]{1,2}$/;
    const ok = regexp.test(antallBarn);
    if (!ok) {
        $("#feilAntallBarn").html("Ugyldig tall!");
        return false;
    } else {
        $("#feilAntallBarn").html("");
        return true;
    }
}

function validerAntallVoksen(antallVoksen) {
    const regexp = /^[0-9]{1,100}$/;
    const ok = regexp.test(antallVoksen);
    if (!ok) {
        $("#feilAntallVoksne").html("Ugyldig tall!");
        return false;
    } else {
        $("#feilAntallVoksne").html("");
        return true;
    }
}

function validerNavn(navn) {
    const regexp = /^[a-zA-ZæøåÆØÅ\.\ \-]{2,30}$/;
    const ok = regexp.test(navn);
    if (!ok) {
        $("#feilRefPerson").html("Navnet må bestå av 2 til 30 bokstaver");
        return false;
    }
    else {
        $("#feilRefPerson").html("");
        return true;
    }
}