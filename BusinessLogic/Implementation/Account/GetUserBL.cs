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
    public class GetUserBL : IGetUserBL
    {
        private IGetUserRepo _getUserRepo;
        public GetUserBL(IGetUserRepo getUserRepo)
        {
            _getUserRepo = getUserRepo;
        }
        //Get User
        public User GetUser(int userId)
        {
            return _getUserRepo.GetUser(userId);
        }
    }
}
