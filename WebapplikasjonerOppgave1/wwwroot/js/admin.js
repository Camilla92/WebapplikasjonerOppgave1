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
            "<td> <a class='btn btn-info' onclick='validerOgEndreTur(" + linje + ")'>Endre</button></td>" +
            "<td> <a class='btn btn-danger' onclick='slettTur(" + linje + ")'>Slett</button></td>" +
            "</tr>" +
            "<tr>" +
            "<td><span id='TurIdFeil" + linje + "' size='3'/> </td>" +
            "<td><span id='feilStartStasjon" + linje + "'/> </td>" +
            "<td><span id='feilEndeStasjonAdmin" + linje + "' /> </td>" +
            "<td><span id='feilDatoAdmin" + linje + "' </td>" +
            "<td><span id='feilTidAdmin" + linje + "' size='5' </td>" +
            "<td><span id='feilBarnePrisAdmin" + linje + "' size='7' </td>" +
            "<td><span id='feilVoksenPrisAdmin" + linje + "' size='7' </td>" +
            "<td><span id='endreFeil" + linje + "' size='7' </td ></tr> ";
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
            "<td> <button class='btn btn-info' onclick='endreTur(" + tur.TurId + ")'>Endre</button></td>" +
            "<td> <button class='btn btn-danger' onclick='slettTur(" + tur.TurId + ")'>Slett</button></td>" +
            "</tr>";
    };
    ut += "</table>";
    $("#turene").html(ut);
}
*/
function validerOgEndreTur(linje) {
    console.log($("#dato"+linje ).val());
    console.log($("#tid"+linje).val());
    console.log($("#barnePris"+linje).val());
    console.log($("#voksenPris"+linje).val());

    const StartstasjonOK = validerStartStasjonEndre($("#startstasjon"+linje).val(), linje);
    const EndestasjonOK = validerEndeStasjonEndre($("#endestasjon"+linje).val(), linje); 
    const DatoOK = validerDatoEndre($("#dato"+linje).val(), linje);
    const TidOK = validerTidEndre($("#tid"+linje).val(), linje);
    const PrisBarnOK = validerBarnePrisEndre($("#barnePris"+linje).val(), linje);
    const PrisVoksenOK = validerVoksenPrisEndre($("#voksenPris"+linje).val(), linje);
    if (StartstasjonOK && EndestasjonOK && TidOK && DatoOK && PrisBarnOK && PrisVoksenOK) {
        EndreTur(linje);
    }
    else {
        $("#feil").html("Feil i inputvalidering");
    }
}


function EndreTur(linje) {
    var data = {
        turId: $("#TurId" + linje).val(),
        startstasjon: $("#startstasjon" + linje).val(),
        endestasjon: $("#endestasjon" + linje).val(),
        dato: $("#dato" + linje).val(),
        tid: $("#tid" + linje).val(),
        barnePris: $("#barnePris" + linje).val(),
        voksenPris: $("#voksenPris" + linje).val()
    }
    var url = "bestilling/EndreTur";
    $.post(url, data, function (turer) {
        if (turer === "Feil innlogging") {
            $(location).attr('href', 'loggInn.html');
        }
        else {
            $(location).attr('href', 'admin.html');
        }
    });
}

function slettTur(linje) {
    var TurId = $("#TurId" + linje).val();
    var url = "/BestillingController/slettTur?TurId" + TurId;
    var slettOK = confirm("Slett tur med tur id" + TurId);
    if (slettOK) {
        $.getJSON(url, function (tur) {
            if (tur === "Feil innlogging") {
                $(location).attr('href', 'loggInn.html');
            }
            else {
                $(location).attr('href', 'admin.html');
            }
        });
    }
}

function loggUt() {
    $.get("/loggUt", function () {
        window.location.href = "loggInn.html";
    })
}
