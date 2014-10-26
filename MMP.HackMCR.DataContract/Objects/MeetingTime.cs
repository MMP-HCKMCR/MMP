using System;

namespace MMP.HackMCR.DataContract.Objects
{
    public class MeetingTime
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int[] UserId { set; get; }
    }
}
