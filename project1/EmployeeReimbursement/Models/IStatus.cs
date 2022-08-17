using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
public interface IStatus
    {
        public enum Status
        {
            Pending = 0,
            Approved = 1,
            Denied = 2,
        }
    }
}