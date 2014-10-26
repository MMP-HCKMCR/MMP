using System;
using System.Collections.Generic;
using System.Linq;
using MMP.HackMCR.BusinessLogic.Object;
using MMP.HackMCR.DataContract;
using MMP.HackMCR.DataContract.Objects;

namespace MMP.HackMCR.BusinessLogic
{
    public class MeetingManager
    {
        private List<User> _usersToProcess = new List<User>();

        public void FindMeetingTimes(int[] userIds, int[] groupIds, int duration, DateTime startDate, DateTime endDate)
        {
            PopulateUsersToProcess(userIds, startDate, endDate);
            PopulateUsersFromGroups(groupIds, startDate, endDate);

            CheckUsersHaveAvailbleMeetingTimeInCalander(duration);

            ProcessMeetingDays();
        }

        private void CheckUsersHaveAvailbleMeetingTimeInCalander(int duration)
        {
            
        }

        private void SelectAvailableMeetingDates()
        {
            
        }

        private void PopulateUsersToProcess(int[] userIds, DateTime startDate, DateTime endDate)
        {
            foreach (var userId in userIds)
            {
                var user = UserManager.GetUser(userId);

                if ((user != null) && !_usersToProcess.Contains(user))
                {
                    user.Entries = OneDiaryInterface.Inferface.GetCalanderEntries(user.Token, startDate, endDate);
                    _usersToProcess.Add(user);
                }
            }
        }

        private void PopulateUsersFromGroups(int[] groupIds, DateTime startDate, DateTime endDate)
        {
            foreach (var groupId in groupIds)
            {
                var users = UserManager.GetUsersForGroupId(groupId);

                foreach (var user in users)
                {
                    if (!_usersToProcess.Contains(user))
                    {
                        user.Entries = OneDiaryInterface.Inferface.GetCalanderEntries(user.Token, startDate, endDate);
                        _usersToProcess.Add(user);
                    }
                }
            }
        }

        private void ProcessMeetingDays()
        {
            foreach (User user in _usersToProcess)
            {
                for (int i = 0; i < 7; i++)
                {
                    GetWorkingHoursForDay(user, i);
                }
            }
        }

        private void GetWorkingHoursForDay(User user, int dayOfWeek)
        {
            DayOfWeek currentDay = DayOfWeek.Sunday;
            switch (dayOfWeek)
            {
                case 0:
                    currentDay = DayOfWeek.Sunday;
                    break;
                case 1:
                    currentDay = DayOfWeek.Monday;
                    break;
                case 2:
                    currentDay = DayOfWeek.Tuesday;
                    break;
                case 3:
                    currentDay = DayOfWeek.Wednesday;
                    break;
                case 4:
                    currentDay = DayOfWeek.Thursday;
                    break;
                case 5:
                    currentDay = DayOfWeek.Friday;
                    break;
                case 6:
                    currentDay = DayOfWeek.Saturday;
                    break;
            }
            var events = LogManager.GetUserLogsForDayOfWeek(user.UserId, currentDay.ToString());

            SeperateEventsIntoDays(user, events, currentDay);
        }

        private void SeperateEventsIntoDays(User user, List<Event> events, DayOfWeek dayOfWeek)
        {
            if (events.Count == 0)
            {
                return;
            }

            var hourDetails = new List<HourDetails>();

            DateTime currentDate = events[0].EventTime;
            Event firstEventOfTheDay = events[0];
            Event lastEventOfTheDay = events[0];

            foreach (var currentEvent in events)
            {
                if (currentDate.ToShortDateString() != currentEvent.EventTime.ToShortDateString())
                {
                    DateTime startTime;
                    DateTime endTime;

                    if (firstEventOfTheDay.UserActive)
                    {
                        startTime =
                            new DateTime(1970, 1, 1, firstEventOfTheDay.EventTime.Hour,
                                firstEventOfTheDay.EventTime.Minute, firstEventOfTheDay.EventTime.Second);
                    }
                    else
                    {
                        startTime =
                            new DateTime(1970, 1, 1, 0, 0, 0);
                    }

                    if (lastEventOfTheDay.UserActive)
                    {
                        endTime =
                            new DateTime(1970, 1, 2, 0, 0, 0);
                    }
                    else
                    {
                        endTime = new DateTime(1970, 1, 1, lastEventOfTheDay.EventTime.Hour,
                            lastEventOfTheDay.EventTime.Minute, lastEventOfTheDay.EventTime.Second);
                    }

                    var details = new HourDetails
                    {
                        StartTime = startTime,
                        EndTime = endTime
                    };

                    hourDetails.Add(details);

                    firstEventOfTheDay = currentEvent;
                    currentDate = currentEvent.EventTime;
                }

                lastEventOfTheDay = currentEvent;
            }

            CalculateWorkingHours(user, hourDetails, dayOfWeek);
        }

        private void CalculateWorkingHours(User user, List<HourDetails> hourDetails, DayOfWeek dayOfWeek)
        {
            var averageStartTicks = (long)hourDetails.Average(s => s.StartTime.Ticks);
            var averageEndTicks = (long)hourDetails.Average(s => s.EndTime.Ticks);

            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    user.SundayStartTime = new DateTime(averageStartTicks);
                    user.SundayEndTime = new DateTime(averageEndTicks);
                    break;
                case DayOfWeek.Monday:
                    user.MondayStartTime = new DateTime(averageStartTicks);
                    user.MondayEndTime = new DateTime(averageEndTicks);
                    break;
                case DayOfWeek.Tuesday:
                    user.TuesdayStartTime = new DateTime(averageStartTicks);
                    user.TuesdayEndTime = new DateTime(averageEndTicks);
                    break;
                case DayOfWeek.Wednesday:
                    user.WednesdayStartTime = new DateTime(averageStartTicks);
                    user.WednesdayEndTime = new DateTime(averageEndTicks);
                    break;
                case DayOfWeek.Thursday:
                    user.ThursdayStartTime = new DateTime(averageStartTicks);
                    user.ThursdayEndTime = new DateTime(averageEndTicks);
                    break;
                case DayOfWeek.Friday:
                    user.FridayStartTime = new DateTime(averageStartTicks);
                    user.FridayEndTime = new DateTime(averageEndTicks);
                    break;
                case DayOfWeek.Saturday:
                    user.SaturdayStartTime = new DateTime(averageStartTicks);
                    user.SaturdayEndTime = new DateTime(averageEndTicks);
                    break;
            }
        }
    }
}
