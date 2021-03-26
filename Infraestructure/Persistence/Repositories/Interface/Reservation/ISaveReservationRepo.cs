using Entity.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Repositories.Interface.Reservation
{
    public interface ISaveReservationRepo
    {
        //Save Reservation 
        int SaveReservation(Flight flight);
    }
}
