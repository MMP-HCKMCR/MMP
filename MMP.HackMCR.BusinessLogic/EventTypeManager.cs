using MMP.HackMCR.DataContract;
using MMP.HackMCR.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMP.HackMCR.BusinessLogic
{
    public static class EventTypeManager
    {
        public static EventType AddEventType(string eventTypeName)
        {
            return MapEventType(EventTypeRepository.AddEventType(eventTypeName));
        }

        public static EventType GetEventType(int eventTypeId)
        {
            return MapEventType(EventTypeRepository.GetEventType(eventTypeId));
        }

        public static List<EventType> GetAllEventTypes()
        {
            return new List<EventType>();
        }

        public static void RemoveEventType(int eventTypeId)
        {
            
        }

        public static EventType UpdateEventType(int eventTypeId, string eventTypeName)
        {
            return new EventType();
        }

        private static EventType MapEventType(DataAccess.Objects.EventType eventType)
        {
            return new EventType
            {
                EventTypeId = eventType.EventTypeId,
                EventTypeName = eventType.EventTypeName
            };
        }
    }
}
