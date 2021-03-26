
using Entity.Account;
using System.Data.Entity;


namespace Infraestructure.Models
{
    public class Context : DbContext
    {
        public Context()
          : base("name=Context")
        {
        }

        public DbSet<User> Users  { get; set; }
        public DbSet<Rol>  Rols { get; set; }
        public DbSet<UserRol> UserRols { get; set; }
    }
}
