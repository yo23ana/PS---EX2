using System;
using System.Collections.Generic;

namespace UserLogin
{
    public static class UserData
    {
        private static List<User> testUser;

        public static List<User> TestUser
        {
            get
            {
                ResetTestUserData();
                return testUser;
            }
            set { }
        }

        private static void ResetTestUserData()
        {
            if (testUser != null) return;

            testUser = new List<User>();
            testUser.Add(new User("Yoana1212", "yoana1212", "", UserRoles.ADMIN, new DateTime(2022, 1, 31)));
            testUser.Add(new User("Didi1313", "didi1313", "121219092", UserRoles.STUDENT, new DateTime(2022, 2, 28)));
            testUser.Add(new User("Denislav1414", "denislav1414", "121219009", UserRoles.STUDENT, new DateTime(2022, 3, 3)));
        }

        public static void GetUsers()
        {
            foreach (var user in testUser)
            {
                Console.WriteLine(user.ToString());
            }
        }

        public static User IsUserPassCorrect(string username, string password)
        {
            foreach (var user in TestUser)
            {
                if (user.username == username && user.password == password)
                    return user;
            }

            return null;
        }

        public static void SetUserActiveTo(string username, DateTime activity)
        {
            foreach (var user in TestUser)
            {
                if (user.username == username)
                {
                    user.Created = activity;
                    Logger.LogActivity("Role changed for " + username);
                }
            }
        }

        public static void AssignUserRole(string username, UserRoles newRole)
        {
            foreach (var user in TestUser)
            {
                if (user.username == username)
                {
                    user.userRole = newRole;
                    Logger.LogActivity("Activity changed for " + username);
                }
            }
        }
    }
}