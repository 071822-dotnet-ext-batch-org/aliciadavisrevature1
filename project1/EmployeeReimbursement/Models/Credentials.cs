
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Credentials() {}
        //parameterized constructor
        public Credentials(string username, string passcode)
        {
            this.Username = username;
            this.Password = passcode;
        }
    }
}
