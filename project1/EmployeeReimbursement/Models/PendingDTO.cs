using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class PendingDTO //Useful ad hoc structure for grouping these pending ticket values and sending it around the program. In this case values from multiple class objects
    {
        public PendingDTO(Guid employeeid, bool manager, Guid ticketid, int status)
        {
            this.employeeid = employeeid;
            this.manager = manager;
            this.ticketid = ticketid;
            this.status = status;
        }
        public Guid employeeid { get; set;}
        public bool manager { get; set;}
        public Guid ticketid { get; set;}
        public int status { get; set;}
    }
}