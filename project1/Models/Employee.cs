using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Employee : Credentials //Inherit Credentials for the respective Employee
    {
        public Employee() {} //parameterized constructor
        public Employee(Guid username)
        {
            this.UserNameID = username;
        }
        public Guid EmployeeID { get; set; } = Guid.NewGuid();
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime DoB { get; set; } = new DateTime(1920, 1, 1);
        public bool Gender { get; set; }//true == female, false == male
        public bool Manager {get; set;}//true == yes, false == no


    }//EoC
}//EoN