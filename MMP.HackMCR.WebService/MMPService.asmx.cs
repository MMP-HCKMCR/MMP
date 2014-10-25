using System.Collections.Generic;
using System.Web.Services;
using MMP.HackMCR.BusinessLogic;
using MMP.HackMCR.DataContract;

namespace MMP.HackMCR.WebService
{
    /// <summary>
    /// Summary description for MMPService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MMPService : System.Web.Services.WebService
    {
        [WebMethod]
        public User AddUser(string name, string userName, string token, string mobileNumber)
        {
            return new User
            {
                UserId = 1,
                Name = name,
                UserName = userName,
                Token = token,
                MobileNumber = mobileNumber,
                Groups = new List<Group>()
            };
        }
        
        [WebMethod]
        public Group AddGroup(string groupName)
        {
            return new Group
            {
                GroupId = 1,
                GroupName = groupName,
                Users = new List<User>()
            };
        }

        [WebMethod]
        public EventType AddEventType(string eventName)
        {
            return new EventType
            {
                EventTypeId = 1,
                EventTypeName = eventName
            };
        }

        [WebMethod]
        public User AddUserToGroup(int userId, int groupId)
        {
            return new User
            {
                UserId = userId,
                UserName = "User Name",
                Token = "Token",
                Name = "Name",
                MobileNumber = "Mobile Number",
                Groups = new List<Group>()
            };
        }

        [WebMethod]
        public User GetUser(int userId)
        {
            return UserManager.GetUser(userId);
        }

        [WebMethod]
        public List<User> GetAllUsers()
        {
            return new List<User>{new User
            {
                UserId = 1,
                Name = "FirstName",
                UserName = "UserName",
                Token = "token",
                MobileNumber = "mobileNumber",
                Groups = new List<Group>()
            }};
        }

        [WebMethod]
        public User GetUser(string userName)
        {
            return new User
            {
                UserId = 1,
                UserName = userName,
                Token = "Token",
                Name = "Name",
                MobileNumber = "Mobile Number",
                Groups = new List<Group>()
            };
        }

        [WebMethod]
        public List<Group> GetAllGroups()
        {
            return new List<Group>{new Group
            {
                GroupId = 1,
                GroupName = "GroupName",
                Users = new List<User>()
            }};
        }

        [WebMethod]
        public Group GetGroup(int groupId)
        {
            return new Group
            {
                GroupId = 1,
                GroupName = "Group Name",
                Users = new List<User>()
            };
        }

        [WebMethod]
        public Group GetGroup(string GroupName)
        {
            return new Group
            {
                GroupId = 1,
                GroupName = GroupName,
                Users = new List<User>()
            };
        }

        [WebMethod]
        public List<EventType> GetAllEventTypes()
        {
            return new List<EventType>
            {
                new EventType
                {
                    EventTypeId = 1,
                    EventTypeName= "Event Type"
                }
            };
        }

        [WebMethod]
        public EventType GetEventType(int eventTypeId)
        {
            return new EventType
            {
                EventTypeId = 1,
                EventTypeName = "Event Type Name"
            };
        }

        [WebMethod]
        public EventType GetEventType(string eventTypeName)
        {
            return new EventType
            {
                EventTypeId = 1,
                EventTypeName = "Event Type Name"
            };
        }

        [WebMethod]
        public List<Group> GetAllGroupsForUser(int userId)
        {
            return new List<Group>
            {
                new Group
                {
                    GroupId = 1,
                    GroupName = "Group Name",
                    Users = new List<User>()
                }
            };
        }

        [WebMethod]
        public List<User> GetAllUsersForGroup(int groupId)
        {
            return new List<User>
            {
                new User
                {
                    UserId = 1,
                    UserName = "User Name",
                    Name = "Name",
                    Token = "Token",
                    MobileNumber = "Mobile Number",
                    Groups = new List<Group>()
                }
            };
        }

        [WebMethod]
        public User UpdateUser(int userId, string userName, string name, string token, string mobileNumber)
        {
            return new User
            {
                UserId = 1,
                UserName = "User Name",
                Token = "Token",
                Name = "Name",
                MobileNumber = "Mobile Number",
                Groups = new List<Group>()
            };
        }

        [WebMethod]
        public Group UpdateGroup(int groupId, string groupName)
        {
            return new Group
            {
                GroupId = 1,
                GroupName = "Group Name",
                Users = new List<User>()
            };
        }

        [WebMethod]
        public EventType UpdateEventType(int eventTypeId, string eventTypeName)
        {
            return new EventType
            {
                EventTypeId = 1,
                EventTypeName = "Event Type Name"
            };
        }

        [WebMethod]
        public void RemoveUserDetails(int userId)
        {

        }

        [WebMethod]
        public void RemoveGroup(int groupId)
        {

        }

        [WebMethod]
        public void RemoveEventType(int eventTypeId)
        {

        }

        [WebMethod]
        public Group RemoveUserFromGroup(int userId, int groupId)
        {
            return new Group
            {
                GroupId = 1,
                GroupName = "Group Name",
                Users = new List<User>()
            };
        }
    }
}
