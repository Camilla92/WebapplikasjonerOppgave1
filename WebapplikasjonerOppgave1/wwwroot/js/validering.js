//TESTE TESTE

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

function validerEpost(Epost) {
    const regexp = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    const ok = regexp.test(Epost);
    if (!ok) {
        $("#feilEpost").html("Epost er skrevet inn feil");
        return false;
    } else {
        $("#feilEpost").html("");
        return true;
    }
}

function validerKortnummer(Kortnummer) {
    const regexp = /^[0-9]{16}$/;
    const ok = regexp.test(Kortnummer);
    if (!ok) {
        $("#feilKortnummer").html("Kortnummer må bestå av 16 tall");
        return false;
    } else {
        $("#feilKortnummer").html("");
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
    return (validerStartstasjon() && validerEndestasjon() && validerDato() &&
        validerTid() && validerFornavn() && validerEtternavn() && validerTelefonnummer()
        && validerEpost() && validerKortnummer && validerAntallBarn() && validerAntallVoksne() );
}

// AdminValidering

function validerBarnePrisAdmin(Barnepris) {
    const regex = /^([0-9.]{2,4}[0-9]{1,2})?$/;
    const ok = regex.test(barnePrisAdmin);
    if (!ok) {
        $("#feilBarnePrisAdmin").html("Barnepris må være mellom 2 og 4 tegn");
        return false;
    } else {
        $("#feilBarnePrisAdmin").html("");
        return true;
    }
}

function validerVoksenPrisAdmin(voksenPrisAdmin) {
    const regex = /^([0-9.]{2,4}[0-9]{1,2})?$/;
    const ok = regex.test(voksenPrisAdmin);
    if (!ok) {
        $("#feilVoksenPrisAdmin").html("Voksenpris må være mellom 2 og fire tegn");
        return false;
    } else {
        $("#feilVoksenPrisAdmin").html("");
        return true;
    }
}

function validerStartStasjonAdmin(startstasjonAdmin) {
    const regexp = /^[a-zA-ZæøåÆØÅ. \-]{2,20}$/;
    const ok = regexp.test(startstasjonAdmin);
    if (!ok) {
        $("#feilStartStasjon").html("Startstasjon må bestå av 2 til 20 bokstaver")
        return false;
    } else {
        $("#feilStartStasjon").html("");
        return true;
    }
}

function validerEndeStasjonAdmin(endestasjonAdmin) {
    const regex = /^[a-zA-ZæøåÆØÅ. \-]{2,20}$/;
    const ok = regex.test(endestasjonAdmin);
    if (!ok) {
        $("#feilEndeStasjonAdmin").html("Endestasjon må bestå av 2 til 20 bokstaver")
        return false;
    } else {
        $("#feilEndeStasjonAdmin").html("");
        return true;
    }
}

function validerDatoAdmin(datoAdmin) {
    const regex = /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/;
    const ok = regex.test(datoAdmin);
    if (!ok) {
        $("#feilDatoAdmin").html("Formatet på dato må være DD/MM/YYYY")
        return false;
    } else {
        $("#feilDatoAdmin").html("");
        return true;
    }
}

function validerTidAdmin(tidAdmin) {
    const regex = /^([01]?[0-9]|2[0-3]):[0-5][0-9]$/;
    const ok = regex.test(tidAdmin);
    if (!ok) {
        $("#feilTidAdmin").html("Formatet på dato må være DD/MM/YYYY")
        return false;
    } else {
        $("#feilTidAdmin").html("");
        return true;
    }
}

function ingenValideringsFeilAdmin() {
    return (validerBarnePrisAdmin() && validerVoksenPrisAdmin() && validerStartStasjonAdmin()
        && validerEndeStasjonAdmin && validerDatoAdmin() && validerTidAdmin());
}





//Tor sitt eksempel: 
function validerBrukernavn(brukernavn) {

    const regex = /^[a-zA-ZæøåÆØÅ\.\\-]{2,20}$/;
    const ok = regex.test(brukernavn);
    if (!ok) {

        $("#feilBrukernavn").html("Brukernavnet må være mellom 2-20 bokstaver");
        return false;
    }
    else {
        $("#feilBrukernavn").html("");
        return true;
    }

}

function validerPassord(passord) {

    const regex = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$/;
    const ok = regex.test(passord);
    if (!ok) {

        $("#feilPassord").html("Feil i passord. Minimum 6 tegn. ");
        return false;
    }
    else {
        $("#feilPassord").html("");
        return true;
    }

}

