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