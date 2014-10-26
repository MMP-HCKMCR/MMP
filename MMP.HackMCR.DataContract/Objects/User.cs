using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MMP.HackMCR.DataContract.Objects;

namespace MMP.HackMCR.DataContract
{
    [DataContract]
    public class User
    {
        int _userId;
        string _userName;
        string _token;
        List<Group> _groups;
        string _mobileNumber;

        [DataMember]
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        [DataMember]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        [DataMember]
        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }

        [DataMember]
        public List<Group> Groups
        {
            get { return _groups; }
            set { _groups = value; }
        }

        [DataMember]
        public string Name { set; get; }

        [DataMember]
        public string MobileNumber
        {
            get { return _mobileNumber; }
            set { _mobileNumber = value; }
        }

        [DataMember]
        public string Email { set; get; }

        [DataMember]
        public Entries Entries { set; get; }

        [DataMember]
        public DateTime SundayStartTime { set; get; }
        [DataMember]
        public DateTime MondayStartTime { set; get; }
        [DataMember]
        public DateTime TuesdayStartTime { set; get; }
        [DataMember]
        public DateTime WednesdayStartTime { set; get; }
        [DataMember]
        public DateTime ThursdayStartTime { set; get; }
        [DataMember]
        public DateTime FridayStartTime { set; get; }
        [DataMember]
        public DateTime SaturdayStartTime { set; get; }

        [DataMember]
        public DateTime SundayEndTime { set; get; }
        [DataMember]
        public DateTime MondayEndTime { set; get; }
        [DataMember]
        public DateTime TuesdayEndTime { set; get; }
        [DataMember]
        public DateTime WednesdayEndTime { set; get; }
        [DataMember]
        public DateTime ThursdayEndTime { set; get; }
        [DataMember]
        public DateTime FridayEndTime { set; get; }
        [DataMember]
        public DateTime SaturdayEndTime { set; get; }
    }
}
