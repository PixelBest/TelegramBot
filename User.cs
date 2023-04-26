using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    internal class User
    {
        public static int Id { get; set; }
        public static string? Phone { get; set; }
        public static string? UserName { get; set; }

        public User(string phone, string userName)
        {
            Phone = phone;
            UserName = userName;
        }
        public User() { }
    }
}
