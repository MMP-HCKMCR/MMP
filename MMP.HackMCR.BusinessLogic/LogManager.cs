using System;
using System.Collections.Generic;
using System.Linq;
using MMP.HackMCR.DataAccess.Repositories;
using MMP.HackMCR.DataContract;

namespace MMP.HackMCR.BusinessLogic
{
    public class LogManager
    {
        public static Event AddLogEntry(int userId, int eventTypeId, DateTime eventTime)
        {
            return MapEvent(LogRespository.AddLogEntry(userId, eventTypeId, eventTime));
        }

        public static List<Event> MapEvents(List<DataAccess.Objects.Log> logs)
        {
            return logs.Select(MapEvent).ToList();
        }

        private static Event MapEvent(DataAccess.Objects.Log log)
        {
            var user = UserManager.GetUser(log.UserId);
            //var eventType = EventTypeManager.GetEventType(log.EventTypeId);

            return new Event
            {
                EventId = log.LogId,
                User = user,
                EventType = new EventType(),
                EventTime = log.EventTime
            };
        }
    }
}
