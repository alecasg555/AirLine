using Entity.Reservation;
using Infraestructure.Persistence.Repositories.Interface.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Repositories.Implementation.Reservation
{
    public class GetFlightRepo : IGetFlightRepo
    {
        private readonly Context db = new Context();
        public Flight GetFlight(int flightId)
        {
            try
            {
                // Get Flight From DB
                Flight flight = db.Flights.Find(flightId);
                return flight;
            }
            catch (Exception e)
            {
                //Log Here
                Console.WriteLine(e);
                throw;
            }
            
        }
        
    }

}
