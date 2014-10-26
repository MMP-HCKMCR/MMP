using System;
using System.Collections.Generic;
using System.Web.Services;
using MMP.HackMCR.BusinessLogic;
using MMP.HackMCR.DataContract;

namespace MMP.HackMCR.Website.WebService
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
        #region User
        [WebMethod]
        public User AddUser(string name, string userName, string token, string mobileNumber, string password, string emailAddress)
        {
            return UserManager.AddUser(name, userName, password, token, mobileNumber, emailAddress);            
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
        public User GetUserById(int userId)
        {
            return UserManager.GetUser(userId);
        }

        [WebMethod]
        public List<User> GetAllUsers()
        {
            return UserManager.GetAllUsers();            
        }

        [WebMethod]
        public User GetUserByName(string userName)
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
        public User UpdateUser(int userId, string userName, string name, string token, string mobileNumber, string password, string emailAddress)
        {
            return new User
            {
                UserId = 1,
                UserName = "User Name",
                Token = "Token",
                Name = "Name",
                Email = "email address",
                MobileNumber = "Mobile Number",
                Groups = new List<Group>()
            };
        }

        [WebMethod]
        public void RemoveUserDetails(int userId)
        {

        }

        [WebMethod]
        public Guid LoginUser(string email, string password)
        {
            var user = UserManager.LoginUser(email, password);
            return SessionManager.AddSession(user.UserId);
        }
        #endregion

        #region Group
        [WebMethod]
        public Group AddGroup(string groupName)
        {
            return GroupManager.AddGroup(groupName);            
        }

        [WebMethod]
        public List<Group> GetAllGroups()
        {
            return GroupManager.GetAllUsers();            
        }

        [WebMethod]
        public Group GetGroupById(int groupId)
        {
            return GroupManager.GetGroup(groupId);            
        }

        [WebMethod]
        public Group GetGroupByName(string GroupName)
        {
            return new Group
            {
                GroupId = 1,
                GroupName = GroupName,
                Users = new List<User>()
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
        public Group UpdateGroup(int groupId, string groupName)
        {
            return GroupManager.UpdateUser(groupId, groupName);
        }

        [WebMethod]
        public void RemoveGroup(int groupId)
        {
            GroupManager.RemoveGroup(groupId);
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
        #endregion

        #region EventType
        [WebMethod]
        public EventType AddEventType(string eventName)
        {
            return EventTypeManager.AddEventType(eventName);
        }

        [WebMethod]
        public List<EventType> GetAllEventTypes()
        {
            return EventTypeManager.GetAllEventTypes();
        }

        [WebMethod]
        public EventType GetEventTypeById(int eventTypeId)
        {
            return EventTypeManager.GetEventType(eventTypeId);
        }

        [WebMethod]
        public EventType GetEventTypeByName(string eventTypeName)
        {
            return new EventType
            {
                EventTypeId = 1,
                EventTypeName = "Event Type Name"
            };
        }

        [WebMethod]
        public EventType UpdateEventType(int eventTypeId, string eventTypeName)
        {
            return EventTypeManager.UpdateEventType(eventTypeId, eventTypeName);
        }

        [WebMethod]
        public void RemoveEventType(int eventTypeId)
        {
            EventTypeManager.RemoveEventType(eventTypeId);
        }
        #endregion                                                                                

        #region Events
        [WebMethod]
        public Event AddUserEventByEventTypeName(string userName, string eventTypeName)
        {
            return new Event
            {
                EventId = 1,
                EventTime = DateTime.UtcNow,
                EventType = new EventType(),
                User = new User()
            };
        }

        [WebMethod]
        public Event AddUserEventByEventTypeId(string userName, int eventTypeId)
        {
            return new Event
            {
                EventId = 1,
                EventTime = DateTime.UtcNow,
                EventType = new EventType(),
                User = new User()
            };
        }
        #endregion

        [WebMethod]
        public void FindMeetingTimes(int[] userIds, int[] groupIds, DateTime startDate, DateTime endDate)
        {
            MeetingManager.FindMeetingTimes(userIds, groupIds, startDate, endDate);
        }
    }
}
