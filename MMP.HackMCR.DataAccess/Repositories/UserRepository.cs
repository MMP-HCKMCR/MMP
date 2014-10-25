using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MMP.HackMCR.DataAccess.Objects;

namespace MMP.HackMCR.DataAccess.Repositories
{
    public static class UserRepository
    {
        public static User GetUser(int userId)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@UserId", userId)
            };

            return PopulateUserFromDataTable(DataHelper.PopulateTable("sp_GetUserForUserId", parameters));
        }

        private static User PopulateUserFromDataTable(DataTable dataTable)
        {
            var result = new User();

            if (dataTable.Rows.Count > 0)
            {

                var dataRow = dataTable.Rows[0];

                result.UserId = dataRow.Field<int>("UserId");
                result.Name = dataRow.Field<string>("Name");
                result.UserName = dataRow.Field<string>("UserName");
                result.Token = dataRow.Field<string>("Token");
                result.MobilePhone = dataRow.Field<string>("MobileNumber");
            }

            return result;
        }
    }
}