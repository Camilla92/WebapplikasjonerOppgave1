$(function () {
    HentAlleStasjoner();
});

function HentAlleStasjoner() {
    $.get("bestilling/hentAlleStasjoner", function (stasjoner) {
        if (stasjoner) {
            listStartStasjoner(stasjoner);
        } else {
            $("#feil").html("Feil i db");
        }
    });
}

function listStartStasjoner(stasjoner) {
    let ut = "<select onchange='listEndeStasjoner()' id='startstasjon'>";
    ut += "<option>Velg startstasjon</option>";
    for (let stasjon of stasjoner) {
        ut += "<option>" + stasjon.stasjonsNavn + "</option>";
    }
    ut += "</select>";
    $("#startstasjon").html(ut);
    console.log(JSON.stringify(stasjoner));
}

function listEndeStasjoner() {
    let startstasjon = $('#startstasjon option:selected').text();
    console.log("StartStasjon: "+startstasjon);
    const url = "bestilling/hentEndeStasjoner?startStasjonsNavn=" + startstasjon;
    $.get(url, function (stasjoner) {
        if (stasjoner) {
            let ut = "<label>Jeg skal reise til</label>";
            ut += "<select>";
            ut += "<option></option>";
            let forrigeStasjon = "";
            for (let stasjon of stasjoner) {
                if (stasjon.stasjonsNavn !== forrigeStasjon) {
                    ut += "<option>" + stasjon.stasjonsNavn + "</option>";
                }
                forrigeStasjon = stasjon.stasjonsNavn;
            }
            ut += "</select>";
            $("#endestasjon").html(ut);
            console.log(JSON.stringify(stasjoner));
        } else {
            $("#feil").html("Feil i db");
        }
    });
}

function antallBarn() {
    var antallBarn = $("#antallBarn");
    $.get("bestilling/barnePris?barnepris=" + antallBarn, function (barnePris) {
        if (barnePris) {
            let ut = barnePris * antallBarn;
            $("#barnePris").html(ut);
        } else {
            $("#feilBarnePris").html("Feil i db");
        });
}


function antallVoksne() {
    var antallVoksne = $("#antallVoksne");
    $.get("bestilling/totalPris?voksenpris=" + antallVoksne, function (voksenPris) {
        if (voksenPris) {
            let ut = voksenPris * antallVoksne;
            $("#voksenPris").html(ut);
        } else {
            $("#feilVoksenPris").html("Feil i db");
        });
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