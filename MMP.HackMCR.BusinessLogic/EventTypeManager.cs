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
            return MapEventTypes(EventTypeRepository.GetAllEventTypes());
        }

        public static void RemoveEventType(int eventTypeId)
        {
            EventTypeRepository.RemoveEventType(eventTypeId);
        }

        public static EventType UpdateEventType(int eventTypeId, string eventTypeName)
        {
            return MapEventType(EventTypeRepository.UpdateEventType(eventTypeId, eventTypeName));
        }

        public static List<EventType> MapEventTypes(List<DataAccess.Objects.EventType> eventTypes)
        {
            return eventTypes.Select(MapEventType).ToList();
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
