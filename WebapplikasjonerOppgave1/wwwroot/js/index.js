$(function () {
    HentAlleStasjoner();
});

function HentAlleStasjoner() {
    $.get("Bestilling/HentAlleStasjoner", function (stasjoner) {
        if (stasjoner) {
            skrivUt(stasjoner);
        } else {
            $("#feil").html("Feil i db");
        }
    });
}


function listDestinasjoner(stasjoner) {
    let ut = "<select id='destinasjon'>";
    for (let stasjon of stasjoner) {
        ut += "<option>" + stasjon + "</option>";
    }
    ut += "</select>";
    $("#stasjon").html(ut);
}

function skrivUt(stasjoner) {
    for (let stasjon of stasjoner) {
        ut += stasjon;
        console.log(ut);
    }
}