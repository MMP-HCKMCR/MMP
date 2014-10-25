using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MMP.HackMCR.DataContract
{
    [DataContract]
    public class Group
    {
        int _groupId;        
        string _groupName;
        List<User> _users;

        [DataMember]
        public int GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }

        [DataMember]
        public string GroupName
        {
            get { return _groupName; }
            set { _groupName = value; }
        }

        [DataMember]
        public List<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }
    }
}
