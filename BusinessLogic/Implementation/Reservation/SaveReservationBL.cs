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
    public class SaveReservationBL : ISaveReservationBL
    {
        private ISaveReservationRepo _reservationRepo;
        public SaveReservationBL(ISaveReservationRepo saveReservationRepo)
        {
            _reservationRepo = saveReservationRepo;
        }
        //Save Reservation
        public int SaveReservation(Flight flight)
        {
            return _reservationRepo.SaveReservation(flight);
        }
    }
}
