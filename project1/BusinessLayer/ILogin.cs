using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface ILogin
    {
        public Task <bool> UserNameAsync(string[] x);
        public bool PassCode(string[] x);
        public void LogSession();
        public bool ValidateUserCredential(string userLoginStr);
        public int EvaluateUserLogin();
        internal void GetAnError();
    }
}