function validerStartstasjon() {
    const valgtStartstasjon = $("#valgtStartstasjon").val();
    if (valgtStartstasjon === "Velg startstasjon") {
        $("#feilStartstasjon").html("Velg en startstasjon");
        return false;
    }
    else {
        $("#feilStartstasjon").html("");
        return true;
    }
}


function validerDato(dato) {
    const regexp = /^(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$/;
    const ok = regexp.test(dato);
    if (!ok) {
        $("#feilDato").html("Dato må være i riktig format");
        return false;
    }
    else {
        $("#feilDato").html("");
        return true;
    }
}


function validerTid() {
    const tid = $("datoValgt").val();
    if (tid === null) {
        $("#feilTid").html("Må velge et tidspunkt");
        return false;
    }
    else {
        $("#feilTid").html("");
        return true;
    }
}


/*
function validerEndestasjon(endestasjon) {
    const endestasjon = $("valgtEndestasjon").val();
    if (endestasjon === "Velg endestasjon") {
        $("#feilEndestasjon").html("Velg endestasjon");
        return false;
    }
    else {
        $("#feilEndestasjon").html("");
        return true;
    }
}*/

// valider dato
// valider tid

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