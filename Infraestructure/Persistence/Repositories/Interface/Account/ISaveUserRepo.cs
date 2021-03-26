using Entity.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Repositories.Interface.Account
{
    public interface ISaveUserRepo
    {
        //Save User 

        int SaveUser(User user);
    }
}
