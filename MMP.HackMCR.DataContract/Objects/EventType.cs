using System.Runtime.Serialization;

namespace MMP.HackMCR.DataContract
{
    [DataContract]
    public class EventType
    {
        private int _eventTypeId;        

        private string _eventTypeName;

        [DataMember]
        public int EventTypeId
        {
            get { return _eventTypeId; }
            set { _eventTypeId = value; }
        }

        [DataMember]
        public string EventTypeName
        {
            get { return _eventTypeName; }
            set { _eventTypeName = value; }
        }        
    }
}
