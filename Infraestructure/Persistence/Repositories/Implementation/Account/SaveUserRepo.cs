using Entity.Account;
using Infraestructure.Persistence.Repositories.Interface.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Repositories.Implementation.Account
{
    public class SaveUserRepo : ISaveUserRepo
    {
        private readonly Context db = new Context();
        public int SaveUser(User user)
        {
            try
            {
                //Adding User To DB
                User NewUser = user;
                db.Users.Add(NewUser);
                db.SaveChanges();
                return NewUser.Id;
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
