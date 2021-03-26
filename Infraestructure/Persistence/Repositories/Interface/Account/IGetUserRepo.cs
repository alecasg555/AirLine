using Entity.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Repositories.Interface.Account
{
    public interface IGetUserRepo
    {
        //Get User 
        User GetUser(int userId); 
    }
}
