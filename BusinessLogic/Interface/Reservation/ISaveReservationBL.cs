using Entity.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface.Reservation
{
    public interface ISaveReservationBL
    {
        //Save Reservation
        int SaveReservation(Flight flight);
    }
}
