function validerStartstasjon() {
    const ikkeValgtSS = $('#startstasjon option:selected').val();
    if (ikkeValgtSS === "Velg startstasjon") {
        $("#feilStartstasjon").html("Må velge en startstasjon");
        return false;
    }
    else {
        $("#feilStartstasjon").html("");
        return true;
    }
}


function validerEndestasjon() {
    const ikkeValgtES = $('#endestasjon option:selected').val();
    if (ikkeValgtES === "Velg endestasjon") {
        $("#feilEndestasjon").html("Må velge en endestasjon");
        return false;
    }
    else {
        $("#feilEndestasjon").html("");
        return true;
    }
}


function validerDato(dato) {
    // regex på formatet: dd/mm/yyyy

    const regexp = /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/;
    
    const ok = regexp.test(dato);
    if (!ok) {
        $("#feilDato").html("Dato må være i riktig format.");
        return false;
    }
    else {
        $("#feilDato").html("");
        return true;
    }
}

function validerTid() {
    const tid = $('#tid option:selected').val();
;
    if (tid === "Velg tidspunkt") {
        $("#feilTid").html("Må velge et tidspunkt");
        return false;
    }
    else {
        $("#feilTid").html("");
        return true;
    }
}

function validerFornavn(fornavn) {
    const regexp = /^[a-zA-ZæøåÆØÅ\.\ \-]{2,20}$/;
    const ok = regexp.test(fornavn);
    if (!ok) {
        $("#feilFornavn").html("Fornavnet må bestå av 2 til 20 bokstaver");
        return false;
    }
    else {
        $("#feilFornavn").html("");
        return true;
    }
}

function validerEtternavn(etternavn) {
    const regexp = /^[a-zA-ZæøåÆØÅ\.\ \-]{2,20}$/;
    const ok = regexp.test(etternavn);
    if (!ok) {
        $("#feilEtternavn").html("Etternavnet må bestå av 2 til 20 bokstaver");
        return false;
    }
    else {
        $("#feilEtternavn").html("");
        return true;
    }
}

function validerTelefonnummer(Telefonnummer) {
    const regexp = /^[0-9]{8}$/;
    const ok = regexp.test(Telefonnummer);
    if (!ok) {
        $("#feilTelefonnummer").html("Telefonnummeret må bestå av 8 tall");
        return false;
    }
    else {
        $("#feilTelefonnummer").html("");
        return true;
    }
}

function validerAntallBarn(AntallBarn) {
    const regexp = /^[0-9]{1}$/;
    const ok = regexp.test(AntallBarn);
    if (!ok) {
        $("#feilAntallBarn").html("Antall barn kan kun bestå av 0-9 stk");
        return false;
    }
    else {
        $("#feilAntallBarn").html("");
        return true;
    }
}

function validerAntallVoksne(AntallVoksne) {
    const regexp = /^[0-9]{1}$/;
    const ok = regexp.test(AntallVoksne);
    if (!ok) {
        $("#feilAntallVoksne").html("Antall voksne kan kun bestå av 0-9 stk");
        return false;
    }
    else {
        $("#feilAntallVoksne").html("");
        return true;
    }
}

function ingenValideringsFeil() {
    return ( validerStartstasjon() && validerEndestasjon() && validerDato() &&
        validerTid() && validerFornavn() && validerEtternavn() && validerTelefonnummer
        && validerAntallBarn() && validerAntallVoksne() );
}