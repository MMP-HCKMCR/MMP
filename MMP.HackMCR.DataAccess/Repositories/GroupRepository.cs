using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using MMP.HackMCR.DataAccess.Objects;

namespace MMP.HackMCR.DataAccess.Repositories
{
    public static class GroupRepository
    {
        public static Group AddGroup(string groupName)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@GroupName", groupName)
            };

            return PopulateGroupFromDataTable(DataHelper.PopulateTable("sp_AddGroup", parameters));
        }

        public static Group UpdateGroup(int groupId, string groupName)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@GroupId", groupId),
                new SqlParameter("@GroupName", groupName)
            };

            return PopulateGroupFromDataTable(DataHelper.PopulateTable("sp_UpdateGroup", parameters));
        }

        public static Group GetGroup(int groupId)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@GroupId", groupId)
            };

            return PopulateGroupFromDataTable(DataHelper.PopulateTable("sp_GetGroupForGroupId", parameters));
        }

        public static void RemoveGroup(int groupId)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@GroupId", groupId)
            };

            DataHelper.PopulateTable("sp_RemoveGroup", parameters);
        }

        public static List<Group> GetAllGroups()
        {
            return PopulateGroupsFromDataTable(DataHelper.PopulateTable("sp_GetAllGroupsAlphabetically", null));
        }

        public static List<Group> GetGroupsForUserId(int userId)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@UserId", userId)
            };

            return PopulateGroupsFromDataTable(DataHelper.PopulateTable("sp_GetGroupsForUserId", parameters));
        }

        private static Group PopulateGroupFromDataTable(DataTable dataTable)
        {
            return dataTable.Rows.Count > 0 ? PopulateGroupFromDataRow(dataTable.Rows[0]) : null;
        }

        private static List<Group> PopulateGroupsFromDataTable(DataTable dataTable)
        {
            return (from DataRow dataRow in dataTable.Rows select PopulateGroupFromDataRow(dataRow)).ToList();
        }

        private static Group PopulateGroupFromDataRow(DataRow dataRow)
        {
            return new Group
            {
                GroupId = dataRow.Field<int>("GroupId"),
                GroupName = dataRow.Field<string>("GroupName")
            };
        }
    }
}
