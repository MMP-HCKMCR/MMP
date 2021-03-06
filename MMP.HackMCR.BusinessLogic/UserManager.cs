﻿using System.Collections.Generic;
using System.Linq;
using MMP.HackMCR.DataAccess.Repositories;
using MMP.HackMCR.DataContract;

namespace MMP.HackMCR.BusinessLogic
{
    public static class UserManager
    {
        public static User AddUser(string name, string userName, string password, string token, string mobileNumber, string email)
        {
            return MapUser(UserRepository.AddUser(name, userName, password, token, mobileNumber, email));
        }

        public static User UpdateUser(int userId, string name, string userName, string password, string token, string mobileNumber, string email)
        {
            return MapUser(UserRepository.UpdateUser(userId, name, userName, password, token, mobileNumber, email));
        }

        public static User GetUser(int userId)
        {
            return MapUser(UserRepository.GetUser(userId));
        }

        public static void RemoveUser(int userId)
        {
            UserRepository.RemoveUser(userId);
        }

        public static List<User> GetAllUsers()
        {
            return MapUsers(UserRepository.GetAllUsers());
        }

        public static List<User> GetUsersForGroupId(int groupId)
        {
            return MapUsers(UserRepository.GetUsersForGroup(groupId), false);
        }

        public static User LoginUser(string email, string password)
        {
            return MapUser(UserRepository.LoginUser(email, password));
        }

        public static List<User> MapUsers(List<DataAccess.Objects.User> users, bool retrieveGroups = true)
        {
            return users.Select(user => MapUser(user, retrieveGroups)).ToList();
        }

        private static User MapUser(DataAccess.Objects.User user, bool retrieveGroups = true)
        {
            if (user == null)
            {
                return null;
            }

            var groups = new List<Group>();

            if (retrieveGroups)
            {
                groups = GroupManager.GetGroupsForUser(user.UserId);
            }

            return new User
            {
                UserId = user.UserId,
                Name = user.Name,
                UserName = user.UserName,
                Token = user.Token,
                MobileNumber = user.MobilePhone,
                Email = user.Email,
                Groups = groups
            };
        }
    }
}
