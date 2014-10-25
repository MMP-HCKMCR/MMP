using System;

namespace MMP.HackMCR.DataAccess.Objects
{
    public class Log
    {
        public int LogId { set; get; }
        public int UserId { set; get; }
        public int EventTypeId { set; get; }
        public DateTime EventTime { set; get; }
    }
}
