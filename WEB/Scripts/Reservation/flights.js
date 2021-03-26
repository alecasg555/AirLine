class Flights {
    flights = {};


    makeReservation(elm) {
        var flightNumber = $(elm.target).data("flight");
        var flightData = this.flights[flightNumber];
        Swal.fire({
            title: 'Estas seguro que deseas reservar el vuelo ' + flightData.DepartureStation + " - " + flightData.ArrivalStation,
            html: 'Tu vuelo sale el dia ' + flightData.DepartureDate,
            icon: 'question',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si, Reservar',
            cancelButtonText: 'Cancelar'
        }).then((result) => {
            if (result.isConfirmed) {
                Swal.mixin({
                    input: 'text',
                    confirmButtonText: 'Ingresar &rarr;',
                    showCancelButton: true,
                    progressSteps: ['1', '2', '3']
                }).queue([
                    {
                        title: 'Ingrese su nombre completo',
                    },
                    {
                        title: 'Ingrese su numero de cedula'
                    },
                    {
                        title: 'Inigrese su numero de telefono'
                    }
                ]).then((result) => {
                    if (result.value) {
                        const dataUser = result.value;
                        var data = {
                            Names: dataUser[0],
                            Document: dataUser[1],
                            Phone: dataUser[2],
                            DepartureStation: flightData.DepartureStation,
                            ArrivalStation: flightData.ArrivalStation,
                            DepartureDate: flightData.DepartureDate,
                            FlightNumber: flightData.FlightNumber,
                            Price: flightData.Price,
                            Currency: flightData.Currency
                        }
                        $.post("/Reservation/MakeReservation", data, function (res) {
                            console.log(res);
                            if (res.Status == 201) {
                                Swal.fire({
                                    title: 'Reserva Realizada!',
                                    icon: 'success',
                                    html: `
                                        Numero de reserva:
                                        <pre><code>${res.Id}</code></pre>
                                      `,
                                    confirmButtonText: 'De Acuerdo!'

                                })
                            } else {
                                Swal.fire({
                                    title: 'Error en la reserva!',
                                    icon: 'error',
                                    html: `hubo un error al realizar la reserva`,
                                    confirmButtonText: 'Aceptar'

                                })
                            }
                        });

                    }
                })

            } else {
                Swal.fire(
                    'Reserva Cancelada!',
                    'Tu reserva ha sido cancelada.',
                    'success'
                )
            }
        })
    }
    showFlight(userFlight) {
        $("#departureStation").text(userFlight.flight.DepartureStation);
        $("#arrivalStation").text(userFlight.flight.ArrivalStation);
        $("#departureDate").text(userFlight.date);
        $("#flightNumber").text(userFlight.flight.FlightNumber);
        $("#price").text(userFlight.flight.Price);
        $("#currency").text(userFlight.flight.Currency);
        $("#name").text(userFlight.user.Names);
        $("#document").text(userFlight.user.Document);
        $("#phone").text(userFlight.user.Phone);
    }
    updateFlights(flightsJson) {
        var flights = JSON.parse(flightsJson);
        flights = JSON.parse(flights);
        this.flights = flights;
    }
    printFlights(response) {
        var flights = JSON.parse(response);
        flights = JSON.parse(flights);

            if (flights.Message == "An error has occurred.") {
                alert("Ha habido un error concacte al administrador");
            } else {
                $("#flightsTableTBody").html("");
                if (flights.length > 0) {

                    $(flights).each(function (index, val) {
                        var formattedDate = val.DepartureDate.replace("T", " ");
                        var tr = "<tr ><td>" + val.DepartureStation + "</td><td>" + val.ArrivalStation + "</td><td>" + formattedDate + "</td><td><button class='btn btn-lg reserva' data-flight='" + index + "'>Reservar</button></td></td>";
                        $("#flightsTableTBody").append(tr);
                    });
                } else {
                    $("#flightsTableTBody").append("<tr class='hidden' id='noResults'><td></td><td></td><td>No se encontraron vuelos</td><td></td></tr>");
                }
            }
        

    }

    validateFields() {
        var from = $("#from").val();
        var to = $("#to").val();
        var date = $("#date").val();

        if (from == "-1") {
            alert("Debe ingresar una ciudad de origen");
            return false;
        } else if (to == "-1") {
            alert("Debe ingresar una ciudad de destino");
            return false;
        } else if (date == "") {
            alert("Debe ingresar una fecha");
            return false;
        }
        return true;
    }
}