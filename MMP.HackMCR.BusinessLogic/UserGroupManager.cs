using MMP.HackMCR.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMP.HackMCR.BusinessLogic
{
    public static class UserGroupManager
    {
        public static void AddUserGroup(int userId, int groupId)
        {
            UserGroupRepository.AddUserGroup(userId, groupId);
        }

        public static void RemoveUserGroup(int userId, int groupId)
        {
            UserGroupRepository.RemoveUserFromGroup(userId, groupId);
        }
    }
}
