using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class ProcessedTicketDto //Useful ad hoc structure for grouping these pending ticket values and sending it around the program. In this case values from multiple class objects
    {
        public ProcessedTicketDto(Guid ticketid, string fname, string lname, string processedStatus)
        {
            this.ticketid = ticketid;
            this.fname = fname;
            this.lname = lname;
            this.processedStatus = processedStatus;
        }
        public Guid ticketid { get; set;}
        public string fname { get; set;}
        public string lname { get; set;}
        public string processedStatus { get; set;}
    }
}