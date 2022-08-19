using Models;
using RepoLayer;

namespace BusinessLayer
{
    public class LoginSession
    {
        private adonetaccess _repoLayer = new adonetaccess();

        //readonly List<Employee> _empdirectory = new List<Employee>; //Create an Employee Directory to house all the employees
        //private readonly List<Credentials> _logins = new List<Credentials>(); //Create a catalog of login credentials
        private Credentials? _CurrentLoginSession = null;
        public Employee? _CurrentEmployee;

        public Ticket? _CurrentTicket;

        /*public LoginSession(Employee q, Credentials c)
        {
            this.E1 = q;
            this.C1 = c;
        }*/

        public Employee E1 { get; set;} = null!;
        public Credentials C1 { get; set;} = null!;

        /*public Credentials ExistsUserName(string username, string password)
        {
            Credentials? C1 = _repo.ExistsUserName(username, password);
            if (C1 == null)
            {
                this._CurrentLoginSession.C1 = new Credentials(username, password);
                return this._CurrentLoginSession.C1;
            }
            else
            {
                this._CurrentLoginSession.UserName = C1;
                return this._CurrentLoginSession;
            }
        }*/


        public async Task<bool> LogonAsync(string username, string password)
        {
            Employee? q = await this._repoLayer.GetUserNameAsync(username, password);
            if (q != null && q.Username == username && q.Password == password) //If employee is in directory with this username and password
            {
                _CurrentEmployee = q;
                return true;
            }
            return false;
        }

        public async Task <bool> RegisterAccountAsync(Employee q)
        {
            q.EmployeeID = " ";
            q.Manager = false;
            return await this._repoLayer.InsertNewUserAsync(q);
        }

        public async Task <bool> SubmitTicketAsync (Ticket t)
        {
            //t.TicketID = Guid.NewGuid();
            return await this._repoLayer.SubmitNewTicketAsync(t);
        }


        public async Task<bool> ProcessPendingTicketsAsync(PendingDTO pdt)
        {
            Employee employee = await this._repoLayer.GetManagerAsync(pdt.GetType);
            Ticket t = await this._repoLayer.PendingTicketsAsync(pdt.statusid);

            return employee.Manager && t?.Status == 0; //Ternary statement to determine if the user is a manger and if the ticket is pending

            if (pdt.newstatus == 1)
            {
                pdt.newstatus = 1;
            }
            else if (pdt.newstatus == 2)
            {
                pdt.newstatus = 2;
            }
            else
            {
                pdt.newstatus = 0;
            }

            bool isSuccess = await this._repoLayer.UpdateTicketAsync(t);
            return isSuccess;
        }

        public async Task <List<Ticket>> GetTicketsAsync(int status)
        {
            List<Ticket> ticketList = await this._repoLayer.GetTicketAsync(status);
            return ticketList;
        }


       /* public async Task<ProcessedTicketDto> ProcessPendingTicketsAsync(PendingDTO p)
        {
            if (await this._repoLayer.IsSheManagerAsync(p.employeeid))
            {
                ProcessedTicketDto processedTicket = await this._repoLayer.ProcessTicketAsync(p.ticketid, p.status);
                return processedTicket;
            }
            return null;
        }*/

        /*public async Task<Request?> TicketAsync(TicketsDTO Ticketobject)
        {//we want the ticket object to be the same as the APIController
            Request ticketRequest = new Request(Guid.NewGuid(), Ticketobject.idEmployee, Ticketobject.Details, Ticketobject.Amount, Ticketobject.Type);
            //Guid.NewGuid() becomes the new requestID

            if (await this._Repository.TicketRequestAsync(ticketRequest))
            {
                return ticketRequest;
            }
            else return null;
        }*/

        /*public async Task <bool>  IsSheManagerAsync(bool Manager)
        {
            if(Manager == true)
            {
                return true;
            }
            else return false;
        }*/

       //private readonly adonetaccess _repoLayer;
       /*public LoginSession(adonetaccess repo)
        {
            _repoLayer = repo;
            this._repoLayer = new adonetaccess();
        }*/

        /*public async Task <Employee> InsertNewUserNameAsync(Employee q)
        {
            Employee? q = await _repo.InsertNewUserNameAsync(fname, lname, username, password);
            if (q == null)
            {
                this._CurrentEmployee.E1 = new Employee(fname, lname, username, password);
                return this._CurrentEmployee.E1;
            }
            else
            {
                this._CurrentEmployee.E1 = q;
                return this._CurrentEmployee.E1;
            }

        }*/

        public Employee GetE1()
        {
            return this._CurrentEmployee;
        }

        public Credentials GetC1()
        {
            return this._CurrentLoginSession;
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

        /*        public async Task <bool> PersistsUserAsync(Employee q)
        {
            if (await this._repoLayer.ExistsUserNameAsync(q.EmployeeID))
            {
                if (await this._repoLayer.UpdateUserNameAsync(q) !=1) return false;
            }
            else if (await this._repoLayer.InsertNewUserNameAsync(q) !=1)
            {
                return false;
            }
            return true;
        }*/

        /*        public async Task <List<Ticket>?> PendingTicketsAsync(int type)
        {
            List<Ticket> list = await this._repoLayer.PendingTicketsAsync(type);
            if (list != null)
            {
                return list;
            }

            return null;
        }*/

