$(function () {
    $.get("Bestilling/HentAlleStartStasjoner", function (startStasjoner) {
        listDestinasjoner(startStasjoner);
    });

});


function listDestinasjoner(StartStasjoner) {
    destinasjonSelect: $("#destinasjon").val()

    var opt;
    for (var i = 0, len = destinasjonSelect.options.length; i < len; i++) {
        opt = destinasjonSelect.options[i];
        if (opt.selected === true) {
            break;
        }
    }
    return opt;

}