$(document).ready(function () {
    const flights = new Flights();
    var date = new Date();
    var dd = String(date.getDate()).padStart(2, '0');
    var mm = String(date.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = date.getFullYear();

    $("#date").attr("min", yyyy+"-"+mm+"-"+dd);
    $("body").on("click", "#btnSearchFlight", function () {
        if (flights.validateFields()) {
        $("#cargando").removeClass("hidden");
            var data = {
                Origin: $("#from").val(),
                Destination: $("#to").val(),
                From: $("#date").val()
            }
            $.post("/Reservation/SearchFlights", data, function (res) {

                $(".resultsDiv").removeClass("hidden");
                if (JSON.parse(res).Message == "An error has occurred.") {
                    $("#noResults").removeClass("hidden");
                } else {
                    flights.updateFlights(res);
                    flights.printFlights(res);
                }
                $("#cargando").addClass("hidden");
            })
        }
    });
    $("body").on("click", ".reserva", function (elm) {
        flights.makeReservation(elm);
    });
});


