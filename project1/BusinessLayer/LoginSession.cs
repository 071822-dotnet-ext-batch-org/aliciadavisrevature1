using System.Security.Cryptography;
using Models;
using RepoLayer;

namespace BusinessLayer
{
    public class LoginSession : ILogin, IGetIt
    {
        private readonly adonetaccess _repo = new adonetaccess();

        //readonly List<Employee> _empdirectory = new List<Employee>; //Create an Employee Directory to house all the employees
        //private readonly List<Credentials> _logins = new List<Credentials>(); //Create a catalog of login credentials
        private Credentials _CurrentLoginSession;
        private Employee _CurrentEmployee;

        /*public Credentials ExistsUserName(string username, string passcode)
        {
            Credentials? C1 = _repo.ExistsUserName(username, passcode);
            if (C1 == null)
            {
                this._CurrentLoginSession.C1 = new Credentials(username, passcode);
                return this._CurrentLoginSession.C1;
            }
            else
            {
                this._CurrentLoginSession.UserName = C1;
                return this._CurrentLoginSession;
            }
        }*/

        public async Task<Credentials> ExistsUserNameAsync(string username = "default", string passcode = "default")
        {
            Credentials? c = await _repo.ExistsUserNameAsync(username, passcode);
            if (c == null)
            {
                this._CurrentLoginSession = new Credentials(username, passcode);
                return this._CurrentLoginSession;
            }
            else
            {
                this._CurrentLoginSession = c;
                return this._CurrentLoginSession;
            }
        }
        public async Task<Employee> IsSheEmployeeAsync(string fname = "default", string lname = "default", bool manager = false)
        {
            Employee? e = await _repo.IsSheEmployeeAsync(fname, lname, manager);
            if (e == null)
            {
                this._CurrentEmployee = new Employee(fname, lname, manager);
                return this._CurrentEmployee;
            }
            else
            {
                this._CurrentEmployee = e;
                return this._CurrentEmployee;
            }
        }
        public async Task <bool>  IsSheManagerAsync(bool Manager)
        {
            if(Manager == true)
            {
                return true;
            }
            else return false;
        }


        public int UpdateTicket(int managerChoice)
        {
            managerChoice = 0;
            if (managerChoice == 1)
            {
                return 1;
            }
            else if(managerChoice == 2)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }

        public Employee GetE1()
        {
            return this._CurrentEmployee;
        }

        public Credentials GetC1()
        {
            return this._CurrentLoginSession;
        }

        bool IGetIt.IsSheManager()
        {
            throw new NotImplementedException();
        }

        int IGetIt.ValidateReimbursementStatus()
        {
            throw new NotImplementedException();
        }

        bool ILogin.PassCode(string[] x)
        {
            throw new NotImplementedException();
        }

        void ILogin.LogSession()
        {
            throw new NotImplementedException();
        }

        bool ILogin.ValidateUserCredential(string userLoginStr)
        {
            throw new NotImplementedException();
        }

        int ILogin.EvaluateUserLogin()
        {
            throw new NotImplementedException();
        }

        void ILogin.GetAnError()
        {
            throw new NotImplementedException();
        }

    }
}