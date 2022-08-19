using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Ticket
    {
        //public Ticket() {} //parameterized constructor
        public Ticket(decimal amount, string description, int status, Guid ticketid, Guid employeeid)
        {
            this.Amount = amount;
            this.Description = description;
            this.Status = status;
            this.TicketID = ticketid;
            this.EmployeeID = employeeid;
        }

        new public Guid EmployeeID { get; set; }
        public Guid TicketID { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

    }
}