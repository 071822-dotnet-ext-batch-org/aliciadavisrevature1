/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace BusinessLayer
{
    public interface ILogin
    {
        public Task<Employee> IsSheEmployeeAsync(string x, string y, bool z);
        public  Task<bool> ExistsUserNameAsync(Guid e);
        public bool PassCode(string[] x);
        public void LogSession();
        public bool ValidateUserCredential(string userLoginStr);
        public int EvaluateUserLogin();
        internal void GetAnError();
    }
}*/