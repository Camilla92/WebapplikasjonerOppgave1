function validerFornavn(Fornavn) {
    const regexp = /^[a-zA-ZæøåÆØÅ\.\ \-]{2,20}$/;
    const ok = regexp.test(Fornavn);
    if (!ok) {
        $("#feilFornavn").html("Fornavnet må bestå av 2 til 20 bokstaver");
        return false;
    }
    else {
        $("#feilFornavn").html("");
        return true;
    }
}

function validerEtternavn(Etternavn) {
    const regexp = /^[a-zA-ZæøåÆØÅ\.\ \-]{2,20}$/;
    const ok = regexp.test(Fornavn);
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