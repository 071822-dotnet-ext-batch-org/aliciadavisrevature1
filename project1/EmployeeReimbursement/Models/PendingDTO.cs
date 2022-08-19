using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class PendingDTO //Useful ad hoc structure for grouping these pending ticket values and sending it around the program. In this case values from multiple class objects
    {
        public PendingDTO(int managerid, bool themanager, int statusid, int newstatus)
        {
            this.mangerid = mangerid;
            this.themanager = themanager;
            this.statusid = statusid;
            this.newstatus = newstatus;
        }
        public int mangerid { get; set;}
        public bool themanager { get; set;}
        public int statusid { get; set;}
        public int newstatus { get; set;}
    }
}