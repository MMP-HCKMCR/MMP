using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MMP.HackMCR.BusinessLogic.Object;
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
                    GetWorkingHoursForDay(user, startDate.AddDays(i));
                }
            }
        }

        private static void GetWorkingHoursForDay(User user, DateTime date)
        {
            var events = LogManager.GetUserLogsForDayOfWeek(user.UserId, date.DayOfWeek.ToString());

            SeperateEventsIntoDays(user, events);
        }

        private static void SeperateEventsIntoDays(User user, List<Event> events)
        {
            var hourDetails = new List<HourDetails>();

            DateTime currentDate = events[0].EventTime;
            Event firstEventOfTheDay = events[0];
            Event lastEventOfTheDay = events[0];

            foreach (var currentEvent in events)
            {
                if (currentDate.ToShortDateString() != currentEvent.EventTime.ToShortDateString())
                {
                    HourDetails details = new HourDetails
                    {
                        StartTime =
                            new DateTime(1970, 1, 1, firstEventOfTheDay.EventTime.Hour, 
                                firstEventOfTheDay.EventTime.Minute, firstEventOfTheDay.EventTime.Second),
                        EndTime = new DateTime(1970, 1, 1, lastEventOfTheDay.EventTime.Hour,
                                                        lastEventOfTheDay.EventTime.Minute, lastEventOfTheDay.EventTime.Second)
                    };

                    hourDetails.Add(details);

                    firstEventOfTheDay = currentEvent;
                    currentDate = currentEvent.EventTime;
                }

                lastEventOfTheDay = currentEvent;
            }

            CalculateWorkingHours(user, hourDetails);
        }

        private static void CalculateWorkingHours(User user, List<HourDetails> hourDetails)
        {
            List<HourDetails> starts = hourDetails.OrderBy(s => s.StartTime).ToList();
            List<HourDetails> ends = hourDetails.OrderBy(s => s.EndTime).ToList();

            int index = 0;

            if (starts.Count%2 != 0)
            {
                index = ((starts.Count - 1)/2) + 1;
            }
            else
            {
                
            }

        }
    }
}
