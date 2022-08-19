using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Employee : Credentials
    {
        //public Employee() {} //parameterized constructor
        public Employee(string fname, string lname, string username, string password, bool manager, string employeeid)
        {
            this.EmployeeID = employeeid;
            this.Fname = fname;
            this.Lname = lname;
            this.Manager = manager;
            this.Username = username;
            this.Password = password;
        }

        public string EmployeeID { get; set; }//Unique Identifier
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Manager {get; set;}//true == yes, false == no
    }//EoC
}//EoN

//: Credentials //Inherit Credentials for the respective Employee