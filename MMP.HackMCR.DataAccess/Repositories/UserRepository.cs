using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MMP.HackMCR.DataAccess.Objects;

namespace MMP.HackMCR.DataAccess.Repositories
{
    public static class UserRepository
    {
        public static User AddUser(string name, string userName, string password, string token, string mobileNumber, string email)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", name),
                new SqlParameter("@UserName", userName),
                new SqlParameter("@Password", password),
                new SqlParameter("@Token", token),
                new SqlParameter("@MobileNumber", mobileNumber),
                new SqlParameter("@Email", email)
            };

            return PopulateUserFromDataTable(DataHelper.PopulateTable("sp_AddUserDetails", parameters));
        }

        public static User UpdateUser(int userId, string name, string userName, string password, string token, string mobileNumber, string email)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@Name", name),
                new SqlParameter("@Password", password),
                new SqlParameter("@UserName", userName),
                new SqlParameter("@Token", token),
                new SqlParameter("@MobileNumber", mobileNumber),
                new SqlParameter("@Email", email)
            };

            return PopulateUserFromDataTable(DataHelper.PopulateTable("sp_UpdateUserDetails", parameters));
        }

        public static User GetUser(int userId)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@UserId", userId)
            };

            return PopulateUserFromDataTable(DataHelper.PopulateTable("sp_GetUserForUserId", parameters));
        }

        public static void RemoveUser(int userId)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@UserId", userId)
            };

            DataHelper.PopulateTable("sp_RemoveUserDetailsForUserId", parameters);
        }

        public static List<User> GetAllUsers()
        {
            return PopulateUsersFromDataTable(DataHelper.PopulateTable("sp_GetAllUsersAlphabetically", null));
        }

        private static User PopulateUserFromDataTable(DataTable dataTable)
        {
            return dataTable.Rows.Count > 0 ? PopulateUserFromDataRow(dataTable.Rows[0]) : null;
        }

        private static List<User> PopulateUsersFromDataTable(DataTable dataTable)
        {
            return (from DataRow dataRow in dataTable.Rows select PopulateUserFromDataRow(dataRow)).ToList();
        }

        private static User PopulateUserFromDataRow(DataRow dataRow)
        {
            return new User
            {
                UserId = dataRow.Field<int>("UserId"),
                Name = dataRow.Field<string>("Name"),
                UserName = dataRow.Field<string>("UserName"),
                Token = dataRow.Field<string>("Token"),
                MobilePhone = dataRow.Field<string>("MobileNumber"),
                Email = dataRow.Field<string>("Email")
            };
        }
    }
}