using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Employee 
    {
        public Employee()
        {
        }

        //public Employee() {} //parameterized constructor
        public Employee(string fname, string lname, bool manager, string username, string passcode)
        {
            this.Fname = fname;
            this.Lname = lname;
            this.Manager = manager;
            this.Username = username;
            this.Password = passcode;
        }

        public Guid EmployeeID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Manager {get; set;}//true == yes, false == no


    }//EoC
}//EoN

//: Credentials //Inherit Credentials for the respective Employee