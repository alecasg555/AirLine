using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface.Reservation
{
    public interface IGetFlightsBL
    {
        //Get Flights
        Task<string> GetFlights(string Origin, string Destination, string From);
    }
}
