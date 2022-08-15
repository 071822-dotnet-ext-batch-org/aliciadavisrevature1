using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace BusinessLayer
{
    public interface IGetIt
    {
        public Credentials GetC1();
        public Employee GetE1();
        public bool IsSheManager();
        public int ValidateReimbursementStatus();
    }
}