using BusinessLogic.Interface.Reservation;
using Entity.Reservation;
using Infraestructure.Persistence.Repositories.Interface.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Implementation.Reservation
{
    public class GetFlightBL : IGetFlightBL
    {
        private IGetFlightRepo _getFlightRepo;
        public GetFlightBL(IGetFlightRepo getFlightRepo)
        {
            _getFlightRepo = getFlightRepo;
        }
        //Get Flight
        public Flight GetFlight(int flightId)
        {
            return _getFlightRepo.GetFlight(flightId);
        }
    }
}
