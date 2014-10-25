using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMP.HackMCR.DataAccess.Objects
{
    public class User
    {
        public int UserId { set; get; }
        public string Name { set; get; }
        public string UserName { set; get; }
        public string Token { set; get; }
        public string MobilePhone { set; get; }
    }
}
