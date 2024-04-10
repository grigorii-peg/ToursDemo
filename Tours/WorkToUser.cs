using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Context.Enum;
using Tours.Context.Models;

namespace Tours
{
    internal static class WorkToUser
    {
        private static User user;

        public static User User
        {
            get
            {
                if (user == null)
                {
                    user = new User()
                    {
                        Id = -1,
                        FirstName = "Неавторизованный гость",
                        LastName = string.Empty,
                        Patronymic = string.Empty,
                        Role = Role.Admin
                    };
                }
                return user;
            }
            set { user = value; }
        }

        internal static bool CompareRole(Role role)
         => role == User.Role;
    }
}
