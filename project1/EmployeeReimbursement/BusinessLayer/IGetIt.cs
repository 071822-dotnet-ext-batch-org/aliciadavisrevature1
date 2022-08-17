using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace BusinessLayer
{
    public interface IGetIt
    {
        public Employee GetC1();
        public Employee GetE1();
        public Ticket GetTicket();
        public bool IsSheManager();
        public int ValidateReimbursementStatus();
        Task<bool> IsSheManagerAsync(bool Manager);
    }
}