$(function () {
    HentAlleStartStasjoner();
});

function HentAlleStartStasjoner() {
    $.get("HentAlleStartStasjoner", function (startStasjoner) {
        listDestinasjoner(startStasjoner);
    });
}


function listDestinasjoner(startStasjoner) {
    let ut = "<select id='destinasjon'>";
    for (const tur of startStasjoner) {
        ut += "<option>" + tur + "</option>";
    }
    ut += "</select>";
    $("#destinasjon").html(ut);


    
}