$(document).ready(function () {
    const flights = new Flights();
    $("body").on("click", "#btnViewFlight", function () {
        $("#cargando").removeClass("hidden");
        var flightId = $("#flightId").val();
        if (flightId == "") {
            Swal.fire('Por favor ingrese el nuero de reserva');
            return false;
        }
        var data = { flightId: flightId };

        $.post("/Reservation/GetFlight", data, function (res) {

            var userFlight = JSON.parse(res);
            flights.showFlight(userFlight);
            $("#cargando").addClass("hidden");

        })
    })
});