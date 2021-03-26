using Entity.Reservation;
using Infraestructure.Persistence.Repositories.Interface.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Repositories.Implementation.Reservation
{
    public class SaveReservationRepo : ISaveReservationRepo
    {
        private readonly Context db = new Context();

        //Save Reservation
        public int SaveReservation(Flight flight)
        {
            try
            {
                //Add Flight To Db
                db.Flights.Add(flight);
                db.SaveChanges();
                return flight.Id;
            }
            catch (Exception e)
            {
                //Log Here
                Console.WriteLine(e);
                return -1;
            }
        }
    }
}
