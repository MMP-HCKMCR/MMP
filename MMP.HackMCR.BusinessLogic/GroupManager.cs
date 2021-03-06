﻿using System.Collections.Generic;
using System.Linq;
using MMP.HackMCR.DataAccess.Repositories;
using MMP.HackMCR.DataContract;

namespace MMP.HackMCR.BusinessLogic
{
    public static class GroupManager
    {
        public static Group AddGroup(string groupName)
        {
            return MapGroup(GroupRepository.AddGroup(groupName));
        }

        public static Group UpdateUser(int groupId, string groupName)
        {
            return MapGroup(GroupRepository.UpdateGroup(groupId, groupName));
        }

        public static Group GetGroup(int groupId)
        {
            return MapGroup(GroupRepository.GetGroup(groupId));
        }

        public static void RemoveGroup(int groupId)
        {
            GroupRepository.RemoveGroup(groupId);
        }

        public static List<Group> GetAllUsers()
        {
            return MapGroups(GroupRepository.GetAllGroups());
        }

        public static List<Group> GetGroupsForUser(int userId)
        {
            return MapGroups(GroupRepository.GetGroupsForUserId(userId), false);
        }

        public static List<Group> MapGroups(List<DataAccess.Objects.Group> groups, bool retrieveUsers = true)
        {
            return groups.Select(group => MapGroup(group, retrieveUsers)).ToList();
        }

        private static Group MapGroup(DataAccess.Objects.Group group, bool retrieveUsers = true)
        {
            if (group == null)
            {
                return null;
            }

            var users = new List<User>();

            if (retrieveUsers)
            {
                users = UserManager.GetUsersForGroupId(group.GroupId);
            }

            return new Group
            {
                GroupId = group.GroupId,
                GroupName = group.GroupName,
                Users = users
            };
        }
    }
}
