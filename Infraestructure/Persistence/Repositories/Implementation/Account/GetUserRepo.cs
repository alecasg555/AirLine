using Entity.Account;
using Infraestructure.Persistence.Repositories.Interface.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Repositories.Implementation.Account
{
    public class GetUserRepo : IGetUserRepo
    {
        private readonly Context db = new Context();
        public User GetUser(int userId)
        {
            User user = db.Users.Find(userId);
            return user;
        }
    }
}
