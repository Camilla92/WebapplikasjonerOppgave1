function loggUt() {
    $.get("Bestilling/LoggUt", function () {
        window.location.href = "loggInn.html";
    })
}