$(function () {
    var url = "bestilling/HentAlleTurer";
    $.get(url, function (turene) {
        if (turene === "Feil innlogging") {
            $(location).attr('href', 'loggInn.html');
        }
        var ut = formaterTurer(turene);
        $("#endreTurene").html(ut);
    });
});


/*
$(function () {
    hentAlleTurer();
});

function hentAlleTurer() {
    $.get("bestilling/HentAlleTurer", function (turene) {
        formaterTurer(turer);
    })
        .fail(function (feil) {
            if (feil.status == 401) {
                window.location.href = 'loggInn.html';
            }
            else {
                $("#feil").html("Feil på server - prøv igjen senere");
            }
        });
}
*/


function formaterTurer(turer) {
    let ut = "<table class='table table-striped'>" +
        "<th>TurId</th>" +
        "<th>Startstasjon</th>" +
        "<th>Endestasjon</th>" +
        "<th>Dato</th>" +
        "<th>Tid</th>" +
        "<th>Barnepris</th>" +
        "<th>Voksenpris</th>" +
        "<th>Endre</th>" +
        "<th>Slett</th>" +
        "</tr>";
    var linje = 1;
    $.each(turer, function (key, tur) {
        ut += "<tr>" +
            "<td><input type='text' readonly id='TurId" + linje + "' size='3' value='" + tur.turId + "'/></td>" +
            "<td><input type='text' id='startstasjon" + linje + "' value='" + tur.startStasjon.stasjonsNavn + "'/></td>" +
            "<td><input type='text' id='endestasjon" + linje + "' value='" + tur.endeStasjon.stasjonsNavn + "'/></td>" +
            "<td> <input type='text' id='dato" + linje + "' value='" + tur.dato + "'/></td>" +
            "<td><input type='text' id='tid" + linje + "' size='5' value='" + tur.tid + "'/></td>" +
            "<td><input type='text' id='barnePris" + linje + "' size='7' value='" + tur.barnePris + "'/></td>" +
            "<td><input type='text' id='voksenPris" + linje + "' size='7' value='" + tur.voksenPris + "'/></td>" +
            "<td> <a class='btn btn-info' onclick='EndreTur(" + linje + ")'>Endre</button></td>" +
            "<td> <a class='btn btn-danger' onclick='SlettTur(" + linje + ")'>Slett</button></td>" +
            "</tr>";
        linje++;
    });
    ut += "</table>";
    return ut;
}

/*

$(function () {
    HentAlleTurer();
});

function HentAlleTurer() {
    $.get("bestilling/HentAlleTurer", function (turer) {
        if (turer) {
            formaterTurer(turer);
        } else {
            $("#feil").html("Feil i db");
        }
    });
}



function formaterTurer(turer) {
    let ut = "<table class='table table-striped'>" +
        "<th>TurId</th>" +
        "<th>Startstasjon</th>" +
        "<th>Endestasjon</th>" +
        "<th>Dato</th>" +
        "<th>Tid</th>" +
        "<th>Barnepris</th>" +
        "<th>Voksenpris</th>" +
        "<th>Endre</th>" +
        "<th>Slett</th>" +
        "</tr>";
    for (const tur of turer) {
        ut += "<tr>" +
            "<td>" + tur.TurId + "</td>" +
            "<td>" + tur.StartStasjon + "</td>" +
            "<td>" + tur.EndeStasjon + "</td>" +
            "<td>" + tur.Dato + "</td>" +
            "<td>" + tur.Tid + "</td>" +
            "<td>" + tur.BarnePris + "</td>" +
            "<td>" + tur.VoksenPris + "</td > " +
            "<td> <button class='btn btn-info' onclick='EndreTur(" + tur.TurId + ")'>Endre</button></td>" +
            "<td> <button class='btn btn-danger' onclick='SlettTur(" + tur.TurId + ")'>Slett</button></td>" +
            "</tr>";
    };
    ut += "</table>";
    $("#turene").html(ut);
}
*/


function EndreTur(linje) {
    var tur = {
        TurId: $("#TurId" + linje).val(),
        startstasjon: $("#startstasjon" + linje).val(),
        endestasjon: $("#endestasjon" + linje).val(),
        dato: $("#dato" + linje).val(),
        tid: $("#tid" + linje).val(),
        barnePris: $("#barnePris" + linje).val(),
        voksenPris: $("#voksenPris" + linje).val()
    }
    var url = "bestilling/EndreTur";
    $.post(url, tur, function (turer) {
        if (turer === "Tur ble ikke registrert") {// må endres
            $(location).attr('href', 'loggInn.html'); // må endres

        }
        else {
            $(location).attr('href', 'admin.html');
        }
    });
}

function SlettTur(linje) {
    var TurId = $("#TurId" + linje).val();
    var slettOK = confirm("Trykk OK for å slette en tur med tur-id: " + TurId);
    if (slettOK) {
        var url = "bestilling/SlettTur?TurId=" + TurId;
        $.get(url, function () {
            window.location.href = "admin.html";
        });
    }
}



