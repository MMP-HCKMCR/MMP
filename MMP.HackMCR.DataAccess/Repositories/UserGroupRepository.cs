using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MMP.HackMCR.DataAccess.Repositories
{
    public static class UserGroupRepository
    {
        public static void AddUserGroup(int userId, int groupId)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@GroupId", groupId)
            };

            DataHelper.PopulateTable("sp_AddUserGroup", parameters);
        }

        public static void RemoveUserFromGroup(int userId, int groupId)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@GroupId", groupId)
            };

            DataHelper.PopulateTable("sp_RemoveUserGroup", parameters);
        }
    }
}
