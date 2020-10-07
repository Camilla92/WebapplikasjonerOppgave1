function loggInn() {

    const brukernavnOK = validerBrukernavn($("#brukernavn").val());
    const passordOK = validerPassord($("#passord").val());

    if (brukernavnOK && passordOK) {

        const bruker = {
            brukernavn: $("#brukernavn").val(),
            passord: $("#passord").val

        }
        $.post("Bestilling/LoggInn", bruker, function (OK) {

            if (OK) {
                window.location.href = 'loggInn.html';

            }
            else {

                $("#feil").html("Feil brukernavn eller passord.");
            }

        })
        .fail(function (){
            
  

            $("#feil").html("Feil på server.");

        });

    }



}