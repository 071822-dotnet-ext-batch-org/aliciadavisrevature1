using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Ticket : Employee, IStatus
    {
        //public Ticket() {} //parameterized constructor
        public Ticket(double amount, string description, int status)
        {
            this.Amount = amount;
            this.Description = description;
            this.Status = status;
        }

        public Ticket()
        {
        }

        private int employeeID;

        public Guid TicketID { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }

        public int Status { get; set; }
        /*public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }*/

    }
}