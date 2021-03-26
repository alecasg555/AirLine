using Entity.Account;
using Entity.Reservation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Repositories
{
    public class Context : DbContext
    {
        public Context()
          : base("name=Context")
        {
        }

        //Account Models

        public DbSet<User> Users { get; set; }
      

        //Reservation Models
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Transport> Transports { get; set; }
    }
}
