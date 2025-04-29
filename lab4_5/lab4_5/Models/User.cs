using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_5
{
   public class User
    {
        public string Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Pfp { get; set; } = "D:\\лабораторные работы\\ооп\\lab4_5\\lab4_5\\Resources\\DefaultPfp.png";
        public User(string username, string password)
        {
            Role = "Client";
            Username = username;
            Password = password;
            if(username == "qwerty" &&  password == "1234")
            {
                Role = "Admin";
            }
            if (username == "йцукен" && password == "1234")
            {
                Role = "Client";
            }
        }
    }
}
