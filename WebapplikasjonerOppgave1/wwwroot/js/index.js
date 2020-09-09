$(function () {
    HentAlleStartStasjoner();
});

function HentAlleStartStasjoner() {
    $.get("Bestilling/HentAlleStartStasjoner", function (startStasjoner) {
        if (startStasjoner) {
            listDestinasjoner(startStasjoner);
        } else {
            $("#feil").html("Feil i db");
        }
    });
}


function listDestinasjoner(startStasjoner) {
    let ut = "<select id='destinasjon'>";
    for (let tur of startStasjoner) {
        ut += "<option>" + tur + "</option>";
    }
    ut += "</select>";
    $("#destinasjon").html(ut);


    
}