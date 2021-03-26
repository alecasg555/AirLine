using BusinessLogic.Interface.Reservation;
using Infraestructure.Persistence.Repositories.Interface.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Implementation.Reservation
{
    public class GetFlightsBL : IGetFlightsBL
    {
        private IGetFlightsRepo _getFlightsRepo;
        public GetFlightsBL(IGetFlightsRepo flightsRepo)
        {
            _getFlightsRepo = flightsRepo;
        }
        //Get Flights
        public Task<string> GetFlights(string Origin, string Destination, string From)
        {
            return _getFlightsRepo.GetFlights(Origin, Destination, From);
        }
    }
}
