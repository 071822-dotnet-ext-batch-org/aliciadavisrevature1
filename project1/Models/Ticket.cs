using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Ticket : Employee
    {
        public Guid TicketID { get; set; } = Guid.NewGuid();
        public double Amount { get; set; }
        public string Description { get; set; }

        public enum Status {EnumMember = 0 };
        public Ticket() {} //parameterized constructor
        public Ticket(Guid employee)
        {
            this.EmployeeID = employee;
        }
    }
}