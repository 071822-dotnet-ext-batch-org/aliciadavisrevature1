using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class UserDTO //Useful ad hoc structure for grouping these user values and sending it around the program
    {
        public string username { get; set; } = "";
        public string password { get; set; } = "";
    }
}