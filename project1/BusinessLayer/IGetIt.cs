using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace BusinessLayer
{
    public interface IGetIt
    {
        public Credentials GetCredentials();
        public Employee GetEmployee();
        public bool IsSheManager();
        public int ValidateReimbursementStatus();
    }
}