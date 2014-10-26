using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMP.HackMCR.DataAccess.Objects;

namespace MMP.HackMCR.DataAccess.Repositories
{
    public static class LogRespository
    {
        public static Log AddLogEntry(int userId, int eventTypeId, DateTime eventTime)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@EventTypeId", eventTypeId),
                new SqlParameter("@EventTime", eventTime)
            };

            return PopulateLogFromDataTable(DataHelper.PopulateTable("sp_AddLogForUserIdAndEventTypeId", parameters));
        }

        public static Log AddLogEntry(string userName, int eventTypeId, DateTime eventTime)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@UserName", userName),
                new SqlParameter("@EventTypeId", eventTypeId),
                new SqlParameter("@EventTime", eventTime)
            };

            return PopulateLogFromDataTable(DataHelper.PopulateTable("sp_AddLogForUserNameAndEventTypeId", parameters));
        }

        public static Log AddLogEntry(string userName, string eventTypeName, DateTime eventTime)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@UserName", userName),
                new SqlParameter("@EventTypeName", eventTypeName),
                new SqlParameter("@EventTime", eventTime)
            };

            return PopulateLogFromDataTable(DataHelper.PopulateTable("sp_AddLogForUserNameAndEventTypeName", parameters));
        }

        public static List<Log> GetUserLogsForDayOfWeek(int userId, string dayOfTheWeek)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@DayOfTheWeek", dayOfTheWeek)
            };

            return PopulateLogsFromDataTable(DataHelper.PopulateTable("sp_GetLogDetailsForUserIdAndDayOfWeek", parameters));
        }

        private static Log PopulateLogFromDataTable(DataTable dataTable)
        {
            return dataTable.Rows.Count > 0 ? PopulateLogFromDataRow(dataTable.Rows[0]) : null;
        }

        private static List<Log> PopulateLogsFromDataTable(DataTable dataTable)
        {
            return (from DataRow dataRow in dataTable.Rows select PopulateLogFromDataRow(dataRow)).ToList();
        }

        private static Log PopulateLogFromDataRow(DataRow dataRow)
        {
            return new Log
            {
                LogId = dataRow.Field<int>("LogId"),
                UserId = dataRow.Field<int>("UserId"),
                EventTypeId = dataRow.Field<int>("EventTypeId"),
                EventTime = dataRow.Field<DateTime>("EventTime"),
                UserActive = dataRow.Field<bool>("UserActive")
            };
        }
    }
}
