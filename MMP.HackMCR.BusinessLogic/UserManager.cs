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
        public static User AddUser(string name, string userName, string token, string mobileNumber)
        {
            return MapUser(UserRepository.AddUser(name, userName, token, mobileNumber));
        }

        public static User GetUser(int userId)
        {
            return MapUser(UserRepository.GetUser(userId));
        }

        private static User MapUser(DataAccess.Objects.User user)
        {
            return new User
            {
                UserId = user.UserId,
                Name = user.Name,
                UserName = user.UserName,
                Token = user.Token,
                MobileNumber = user.MobilePhone,
                Groups = new List<Group>()
            };
        }
    }
}
