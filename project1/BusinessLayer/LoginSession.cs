using Models;
using RepoLayer;

namespace BusinessLayer
{
    public class LoginSession : ILogin, IGetIt
    {
        private readonly adonetaccess _repo = new adonetaccess();

        readonly List<Employee> _empdirectory = new List<Employee>; //Create an Employee Directory to house all the employees
        private readonly List<Credentials> _logins = new List<Credentials>(); //Create a catalog of login credentials
        private Credentials _CurrentLoginSession;

        public LoginSession()
        {
        }

        public async Task <bool> UserNameAsync(string[] UserName)
        {
            string username, passcode;
            if (UserName.Length > 1)
            {
                username = UserName[0];
                passcode = UserName[1];
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task <bool>  IsSheManagerAsync()
        {
            if(Manager == true)
            {
                return true;
            }
            else return false;
        }


        public int ValidateReimbursementStatus()
        {
            if(managerChoice == 1)
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
    }
}