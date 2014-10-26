using System;
using System.Collections.Generic;
using System.Linq;

namespace MMP.HackMCR.BusinessLogic
{
    public class MeetingManager
    {
        public static void FindMeetingTimes(int[] userIds, int[] groupIds, DateTime startDate, DateTime endDate)
        {
            var userIdsToProcess = PopulateUsersToProcess(userIds);
            userIdsToProcess = PopulateUsersFromGroups(groupIds, userIdsToProcess);
        }

        private static List<int> PopulateUsersToProcess(int[] userIds)
        {
            var userIdsToProcess = new List<int>();

            foreach (var userId in userIds)
            {
                if (!userIdsToProcess.Contains(userId))
                {
                    userIdsToProcess.Add(userId);
                }
            }

            return userIdsToProcess;
        }

        private static List<int> PopulateUsersFromGroups(int[] groupIds, List<int> userIdsToProcess)
        {
            foreach (var user in 
                        from groupId in groupIds 
                        select UserManager.GetUsersForGroupId(groupId) 
                        into users from user in users 
                        where !userIdsToProcess.Contains(user.UserId) select user)
            {
                userIdsToProcess.Add(user.UserId);
            }

            return userIdsToProcess;
        }
    }
}
