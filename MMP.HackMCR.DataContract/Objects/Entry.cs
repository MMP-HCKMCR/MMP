using System;

namespace MMP.HackMCR.DataContract.Objects
{
    public class Entry
    {
        public string calendar_id { set; get; }

        public string event_id { set; get; }
        public string event_uid { set; get; }
        public string summary { set; get; }
        public string description { set; get; }
        public string start { set; get; }
        public string end { set;get; }
        public DateTime StartTime
        {
            get
            {
                DateTime result;
                DateTime.TryParse(start, out result);
                return result;
            }
        }
        public DateTime EndTime {
            get
            {
                DateTime result;
                DateTime.TryParse(end, out result);
                return result;
            }
        }
    }
}
