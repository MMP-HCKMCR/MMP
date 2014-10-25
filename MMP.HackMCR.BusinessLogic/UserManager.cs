using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMP.HackMCR.DataAccess.Repositories;
using MMP.HackMCR.DataContract;

namespace MMP.HackMCR.BusinessLogic
{
    public static class UserManager
    {
        public static User GetUser(int userId)
        {
            var user = UserRepository.GetUser(userId);

            var result = new User
            {
                UserId = user.UserId,
                Name = user.Name,
                UserName = user.UserName,
                Token = user.Token,
                MobileNumber = user.MobilePhone,
                Groups = new List<Group>()
            };

            return result;
        }
    }
}
