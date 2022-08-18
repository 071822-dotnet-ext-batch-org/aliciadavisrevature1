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
        private Employee _CurrentLoginSession;
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

        public async Task<Employee> ExistsUserNameAsync(Guid employeeid, string username = "default", string passcode = "default", bool manager = false, string fname ="default", string lname = "default")
        {
            Employee? c = await _repo.ExistsUserNameAsync(employeeid, username, passcode, manager, fname, lname);
            if (c == null)
            {
                this._CurrentLoginSession = new Employee(employeeid, username, passcode, manager, fname, lname);
                return this._CurrentLoginSession;
            }
            else
            {
                this._CurrentLoginSession = c;
                return this._CurrentLoginSession;
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

       private readonly adonetaccess _repoLayer;
       public LoginSession()
        {
            this._repoLayer = new adonetaccess();
        }

        public async Task <List<Ticket>?> PendingTicketsAsync(int type)
        {
            List<Ticket> list = await this._repoLayer.PendingTicketsAsync(type);
            if (list != null)
            {
                return list;
            }

            return null;
        }
        Ticket IGetIt.GetTicket()
        {
            throw new NotImplementedException();
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

        public Employee GetC1()
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

        Task<Employee> ILogin.IsSheEmployeeAsync(string x, string y, bool z)
        {
            throw new NotImplementedException();
        }

        Task<Employee> ILogin.ExistsUserNameAsync(string x, string y, bool z, string a, string b)
        {
            throw new NotImplementedException();
        }
    }
}

       /* public async Task<Employee> IsSheEmployeeAsync(string fname = "default", string lname = "default", bool manager = false)
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
        }*/