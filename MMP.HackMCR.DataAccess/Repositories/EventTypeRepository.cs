using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MMP.HackMCR.DataAccess.Objects;

namespace MMP.HackMCR.DataAccess.Repositories
{
    public static class EventTypeRepository
    {
        public static EventType AddEventType(string eventTypeName)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@EventTypeName", eventTypeName)
            };

            return PopulateEventTypeFromDataTable(DataHelper.PopulateTable("sp_AddEventType", parameters));
        }

        public static EventType GetEventType(int eventTypeId)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@EventTypeId", eventTypeId)
            };

            return PopulateEventTypeFromDataTable(DataHelper.PopulateTable("sp_GetEventTypeForEventTypeId", parameters));
        }

        public static List<EventType> GetAllEventTypes()
        {
            return PopulateEventTypesFromDataTable(DataHelper.PopulateTable("sp_GetAllEventTypesAlphabetically", null));
        }

        public static EventType UpdateEventType(int eventTypeId, string eventTypeName)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@EventTypeId", eventTypeId),
                new SqlParameter("@EventTypeName", eventTypeName)
            };

            return PopulateEventTypeFromDataTable(DataHelper.PopulateTable("sp_UpdateUserDetails", parameters));
        }

        public static void RemoveEventType(int eventTypeId)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@EventTypeId", eventTypeId)
            };

            DataHelper.PopulateTable("sp_RemoveEventType", parameters);
        }

        private static EventType PopulateEventTypeFromDataTable(DataTable dataTable)
        {
            return dataTable.Rows.Count > 0 ? PopulateEventTypeFromDataRow(dataTable.Rows[0]) : null;
        }

        private static List<EventType> PopulateEventTypesFromDataTable(DataTable dataTable)
        {
            return (from DataRow dataRow in dataTable.Rows select PopulateEventTypeFromDataRow(dataRow)).ToList();
        }

        private static EventType PopulateEventTypeFromDataRow(DataRow dataRow)
        {
            return new EventType
            {
                EventTypeId = dataRow.Field<int>("EventTypeId"),
                EventTypeName = dataRow.Field<string>("EventTypeName")
            };
        }
    }
}
