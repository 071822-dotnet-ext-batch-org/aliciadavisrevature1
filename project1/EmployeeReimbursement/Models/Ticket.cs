using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Ticket
    {
        //public Ticket() {} //parameterized constructor
        public Ticket(decimal amount, string description, int status, string ticketid, string employeeid)
        {
            this.Amount = amount;
            this.Description = description;
            this.Status = status;
            this.TicketID = ticketid;
            this.EmployeeID = employeeid;
        }

        new public string EmployeeID { get; set; }
        public string TicketID { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

    }
}