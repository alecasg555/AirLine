using BusinessLogic.Interface.Account;
using Entity.Account;
using Infraestructure.Persistence.Repositories.Interface.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Implementation.Account
{
    public class SaveUserBL : ISaveUserBL
    {
        private ISaveUserRepo _saveUserRepo;
        public SaveUserBL(ISaveUserRepo saveUserRepo)
        {
            _saveUserRepo = saveUserRepo;
        }
        //Save User
        public int SaveUser(User user)
        {
            return _saveUserRepo.SaveUser(user);
        }
    }
}
