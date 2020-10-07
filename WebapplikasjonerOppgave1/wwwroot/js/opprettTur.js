/*function validerOgLagTur() {
    const StartstasjonOK = validerStartStasjonAdmin($("#startstasjon").val());
    const EndestasjonOK = validerEndeStasjonAdmin($("#endestasjon").val()); @
        const DatoOK = validerDatoAdmin($("#feilDatoAdmin").val());
    const TidOK = validerTidAdmin($("#feilTidAdmin").val());
    const FornavnOK = validerFornavn($("#fornavn").val());
    const EtternavnOK = validerEtternavn($("#etternavn").val());
    const TelefonnummerOK = validerTelefonnummer($("#telefonnr").val());
    const AntallBarnOK = validerAntallBarn($("#antallBarn").val());
    const AntallVoksneOK = validerAntallVoksne($("#antallVoksne").val());
    if (StartstasjonOK && EndestasjonOK && TidOK && FornavnOK && EtternavnOK
        && TelefonnummerOK && AntallBarnOK && AntallVoksneOK) {
        lagMinEgenPopUp();
    }
}*/


function opprettTur() {
    const tur = {
        startstasjon: $("#startstasjon").val(),
        endestasjon: $("#endestasjon").val(),
        dato: $("#dato").val(),
        tid: $("#tid").val(),
        barnepris: $("#barnepris").val(),
        voksenpris: $("#voksenpris").val()
    }

    const url = "bestilling/opprettTur";
    $.post(url, tur, function () {
        window.location.href = 'admin.html';
        console.log("Tur er opprettet!");
    })
        .fail(function () {
            $("#feil").html("Feil på server - prøv igjen senere");
        });
};