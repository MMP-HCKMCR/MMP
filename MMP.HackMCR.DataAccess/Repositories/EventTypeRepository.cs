using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MMP.HackMCR.DataAccess.Objects;

namespace MMP.HackMCR.DataAccess.Repositories
{
    public class EventTypeRepository
    {
        public EventType AddEventType(string eventTypeName)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@EventTypeName", eventTypeName)
            };

            return PopulateEventTypeFromDataTable(DataHelper.PopulateTable("sp_AddEventType", parameters));
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
