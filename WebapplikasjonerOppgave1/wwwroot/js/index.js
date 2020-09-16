$(function () {
    HentAlleStasjoner();
});

function HentAlleStasjoner() {
    $.get("bestilling/hentAlleStasjoner", function (stasjoner) {
        if (stasjoner) {
            listDestinasjoner(stasjoner);
        } else {
            $("#feil").html("Feil i db");
        }
    });
}


function listDestinasjoner(stasjoner) {
    let ut = "<select id='destinasjon'>";
    for (let stasjon of stasjoner) {
        ut += "<option>" + stasjon.stasjonsNavn + "</option>";
    }
    ut += "</select>";
    $("#stasjon").html(ut);
    console.log(JSON.stringify(stasjoner));
}

function validerOgLagBestilling() {
    const FornavnOK = validerFornavn($("#fornavn").val());
    const EtternavnOK = validerEtternavn($("#etternavn").val());
    const TelefonnummerOK = validerTelefonnummer($("#telefonnr").val());
    const AntallBarnOK = validerAntallBarn($("#antallBarn").val());
    const AntallVoksneOK = validerAntallVoksne($("#antallVoksne").val());
    if (FornavnOK && EtternavnOK && TelefonnummerOK && AntallBarnOK && AntallVoksneOK) {
        lagreBestilling();
    }
}

function lagreBestilling() {
    const bestilling = {
        fornavn: $("#fornavn").val(),
        etternavn: $("#etternavn").val(),
        telefonnummer: $("#telefonnr").val(),
        antallBarn: $("#antallBarn").val(),
        antallVoksne: $("#antallVoksne").val(),
        //totalPris: $("#totalPris").val(),
        tid: $("#tid").val(),
        startStasjon: $("#startstasjon").val(),
        endeStasjon: $("#endestasjon").val()
    }
    const url = "bestilling/lagre";
    $.post(url, bestilling, function () {
        window.location.href = 'index.html';
    })
        .fail(function () {
            $("#feil").html("Feil på server - prøv igjen senere");
        });
};
