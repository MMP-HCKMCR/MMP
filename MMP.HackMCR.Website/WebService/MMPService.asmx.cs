using System;
using System.Collections.Generic;
using System.Web.Services;
using MMP.HackMCR.BusinessLogic;
using MMP.HackMCR.DataContract;
using MMP.HackMCR.DataContract.Objects;

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
        public void AddUserToGroup(int userId, int groupId)
        {
            UserGroupManager.AddUserGroup(userId, groupId); 
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
        public User UpdateUser(int userId, string userName, string name, string token, string mobileNumber, string password, string emailAddress)
        {
            return UserManager.UpdateUser(userId, name, userName, password, token, mobileNumber, emailAddress);
        }

        [WebMethod]
        public void RemoveUserDetails(int userId)
        {
            UserManager.RemoveUser(userId);
        }

        [WebMethod]
        public string LoginUser(string email, string password)
        {
            var user = UserManager.LoginUser(email, password);

            if (user == default(User))
            {
                return string.Empty;
            }

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
        public List<Group> GetAllGroupsForUser(int userId)
        {
            return GroupManager.GetGroupsForUser(userId);
        }

        [WebMethod]
        public List<User> GetAllUsersForGroup(int groupId)
        {
            return UserManager.GetUsersForGroupId(groupId);
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
        public void RemoveUserFromGroup(int userId, int groupId)
        {
            UserGroupManager.RemoveUserGroup(userId, groupId);
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
        public MeetingTime[] FindMeetingTimes(int[] userIds, int[] groupIds, int duration, string startDate, string endDate)
        {
            DateTime realStartDate;
            DateTime.TryParse(startDate, out realStartDate);

            DateTime realEndDate;
            DateTime.TryParse(endDate, out realEndDate);

            var meetingManager = new MeetingManager();
            return meetingManager.FindMeetingTimes(userIds, groupIds, duration, realStartDate, realEndDate).ToArray();
        }

        [WebMethod]
        public void CreateMeeting(string userToken, List<User> users, Entry entry)
        {
            OneDiaryInterface.Inferface.AddCalanderEntry(userToken, users, entry);
        }

        [WebMethod]
        public void CancelMeeting(string userToken, List<User> users, int eventId)
        {
            OneDiaryInterface.Inferface.RemoveCalanderEntry(userToken, users, eventId);
        }

        [WebMethod]
        public int ValidateSession(string guid)
        {
            return SessionManager.ValidateSession(guid);
        }
    }
}
