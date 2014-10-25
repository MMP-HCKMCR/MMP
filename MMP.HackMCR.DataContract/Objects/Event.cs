using System;
using System.Runtime.Serialization;

namespace MMP.HackMCR.DataContract
{
    [DataContract]
    public class Event
    {
        int _eventId;
        User _user;
        EventType _eventType;
        DateTime _eventTime;        

        [DataMember]
        public int EventId
        {
            get { return _eventId; }
            set { _eventId = value; }
        }

        [DataMember]
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        [DataMember]
        public EventType EventType
        {
            get { return _eventType; }
            set { _eventType = value; }
        }

        [DataMember]
        public DateTime EventTime
        {
            get { return _eventTime; }
            set { _eventTime = value; }
        }
    }
}
