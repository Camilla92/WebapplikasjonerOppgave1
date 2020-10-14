function validerOgLagTur() {
    const StartstasjonOK = validerStartStasjonAdmin($("#startstasjonAdmin").val());
    const EndestasjonOK = validerEndeStasjonAdmin($("#endestasjonAdmin").val());
    const DatoOK = validerDatoAdmin($("#datoAdmin").val());
    const TidOK = validerTidAdmin($("#tidAdmin").val());
    const BarnePrisOK = validerBarnePrisAdmin($("#barnePrisAdmin").val());
    const VoksenPrisOK = validerVoksenPrisAdmin($("#voksenPrisAdmin").val());
    if (StartstasjonOK && EndestasjonOK && DatoOK && TidOK && BarnePrisOK && VoksenPrisOK) {
        opprettTur();
    }
}


function opprettTur() {

    const tur = {
        startstasjon: $("#startstasjonAdmin").val(),
        endestasjon: $("#endestasjonAdmin").val(),
        dato: $("#datoAdmin").val(),
        tid: $("#tidAdmin").val(),
        barnepris: $("#barnePrisAdmin").val(),
        voksenpris: $("#voksenPrisAdmin").val()
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

