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
    console.log("StartStasjon: " + startstasjon);
    const url = "bestilling/hentEndeStasjoner?startStasjonsNavn=" + startstasjon;
    $.get(url, function (stasjoner) {
        if (stasjoner) {
            let ut = "<label>Jeg skal reise til</label>";
            ut += "<select onchange='listDato()'>";
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

function listDato() {
    let ut = "<label>Velg dato<span> (DD/MM/ÅÅÅÅ) </span></label>";
    ut += "<input type='text' id='datoValgt' onchange='listTidspunkt()'>";
    $("#dato").html(ut);
   
}

function listTidspunkt() {
    let dato = document.getElementById('datoValgt').value;
    let startstasjon = $('#startstasjon option:selected').text();
    let endestasjon = $('#endestasjon option:selected').text();
    console.log("Dato: " + dato + ", startstasjon: " + startstasjon + ", endestasjon: " + endestasjon);
    const url = "bestilling/hentAlleTurer";
    $.get(url, function (turer) {
        if (turer) {
            let ut = "<label>Velg tidspunkt</label>";
            ut += "<select id='tidspunkt'>";
            for (let tur of turer) {
                console.log("Utenfor if, tur sin tid:" + tur.tid);
                if (startstasjon === tur.startStasjon.stasjonsNavn && endestasjon === tur.endeStasjon.stasjonsNavn && dato === tur.dato) {
                    ut += "<option>" + tur.tid + "</option>";
                    console.log("Tur sin tid:" + tur.tid);
                }
            }
            ut += "</select>";
            $("#tid").html(ut);
            console.log(JSON.stringify(turer));
        }
        else {
            $("#feil").html("Feil i db");
        }
    });

}

function validerOgLagBestilling() {
    const StartstasjonOK = validerStartstasjon($("#startstasjon").val());
    //const EndestasjonOK = validerEndestasjon($("#endestasjon").val());
    const FornavnOK = validerFornavn($("#fornavn").val());
    const EtternavnOK = validerEtternavn($("#etternavn").val());
    const TelefonnummerOK = validerTelefonnummer($("#telefonnr").val());
    const AntallBarnOK = validerAntallBarn($("#antallBarn").val());
    const AntallVoksneOK = validerAntallVoksne($("#antallVoksne").val());
    if (StartstasjonOK && FornavnOK && EtternavnOK && TelefonnummerOK && AntallBarnOK && AntallVoksneOK) {
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
        //tid: $("#tid").val(),
        startstasjon: $("#startstasjon").val(),
        //endeStasjon: $("#endestasjon").val()
    }
    const url = "bestilling/lagre";
    $.post(url, bestilling, function () {
        window.location.href = 'index.html';
    })
        .fail(function () {
            $("#feil").html("Feil på server - prøv igjen senere");
        });
};