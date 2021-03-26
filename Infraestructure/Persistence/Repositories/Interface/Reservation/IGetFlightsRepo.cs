using Entity.Account;
using Entity.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Repositories.Interface.Reservation
{
    public interface IGetFlightsRepo
    {
        //Get Flights 
        Task<string> GetFlights(string Origin, string Destination, string From);
        
    }
}
