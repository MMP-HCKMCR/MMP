using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMP.HackMCR.DataContract.Objects
{
    public class Calendar
    {
        public string provider_name { set; get; }
        public string profile_name { set; get; }
        public string calendar_id { set; get; }
        public string calendar_name { set; get; }
        public string calendar_readonly { set; get; }
    }
}
