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