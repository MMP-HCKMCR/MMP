using System;
using System.Collections.Generic;
using System.Linq;
using MMP.HackMCR.DataContract;

namespace MMP.HackMCR.BusinessLogic
{
    public class MeetingManager
    {
        public static void FindMeetingTimes(int[] userIds, int[] groupIds, DateTime startDate, DateTime endDate)
        {
            var usersToProcess = PopulateUsersToProcess(userIds, startDate, endDate);
            usersToProcess = PopulateUsersFromGroups(groupIds, usersToProcess, startDate, endDate);

            ProcessMeetingDays(usersToProcess, startDate, endDate);
        }

        private static List<User> PopulateUsersToProcess(int[] userIds, DateTime startDate, DateTime endDate)
        {
            var usersToProcess = new List<User>();

            foreach (var userId in userIds)
            {
                var user = UserManager.GetUser(userId);

                if ((user != null) && !usersToProcess.Contains(user))
                {
                    user.Entries = OneDiaryInterface.Inferface.GetCalanderEntries(user.Token, startDate, endDate);
                    usersToProcess.Add(user);
                }
            }

            return usersToProcess;
        }

        private static List<User> PopulateUsersFromGroups(int[] groupIds, List<User> usersToProcess, DateTime startDate, DateTime endDate)
        {
            foreach (var groupId in groupIds)
            {
                var users = UserManager.GetUsersForGroupId(groupId);

                foreach (var user in users)
                {
                    if (!usersToProcess.Contains(user))
                    {
                        user.Entries = OneDiaryInterface.Inferface.GetCalanderEntries(user.Token, startDate, endDate);
                        usersToProcess.Add(user); 
                    }
                }
            }

            return usersToProcess;
        }

        private static void ProcessMeetingDays(List<User> usersToProcess, DateTime startDate, DateTime endDate)
        {
            var numberOfDays = endDate.Subtract(startDate).Days;

            foreach (User user in usersToProcess)
            {
                for (int i = 0; i < numberOfDays; i++)
                {
                    GetWorkingHoursForDay(user.UserId, startDate.AddDays(i));
                }
            }
        }

        private static void GetWorkingHoursForDay(int userId, DateTime date)
        {
            var events = LogManager.GetUserLogsForDayOfWeek(userId, date.DayOfWeek.ToString());
        }
    }
}
