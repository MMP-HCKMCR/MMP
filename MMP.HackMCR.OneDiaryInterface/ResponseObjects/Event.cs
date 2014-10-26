using System;

namespace MMP.HackMCR.OneDiaryInterface.ResponseObjects
{
    public class Event
    {
        public string calendar_id { set; get; }
        public string event_uid { set; get; }
        public string summary { set; get; }
        public string description { set; get; }
        public string start { set; get; }
        public string end { set;get; }
    }
}
