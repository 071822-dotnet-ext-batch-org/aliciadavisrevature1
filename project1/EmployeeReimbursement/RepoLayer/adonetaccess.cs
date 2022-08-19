using System.Security.Cryptography;
using System.Reflection.Emit;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System;
using Models;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace RepoLayer

{
    public class adonetaccess
    {
        public object q { get; set; }
        public object t { get; set; }

        private static readonly SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        public async Task<Employee> GetUserNameAsync(string username, string password)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using SqlCommand command = new SqlCommand($"SELECT * FROM Employees WHERE Username = @username AND Password = @password", conn);
            command.Parameters.AddWithValue("@username", username);//adding dynamic data will protect against SQL Injection
            command.Parameters.AddWithValue("@password", password);
            conn.Open();
            SqlDataReader? ret = await command.ExecuteReaderAsync();
            if (ret.Read())
            {
                Employee q = new Employee(
                    ret.GetString(0),
                    ret.GetString(1),
                    /*q.Username =*/ret.GetString(2),
                    /*q.Password =*/ret.GetString(3),
                    ret.GetBoolean(4),
                    ret.GetGuid(5)
                );
                return q;
            }
            else
            {
                conn.Close();
                return null;
            }
        }//EoGetUserNameAsync

        public async Task<bool> ExistsUserNameAsync(Guid employeeid)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT Top 1 * FROM Employees WHERE EmployeeID = @umployeeid", conn))
            {
                command.Parameters.AddWithValue("@employeeid", employeeid);//adding dynamic data will protect against
                conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                if(ret.Read())
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
           }
        }//EoExistsUserNameAsync



        public async Task<bool> InsertNewUserAsync(Employee q) //bool instead of int. Not sure how it started as int, but the insertion will either be a success or failure so use bool
        {
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"INSERT INTO Employees VALUES (@fname, @lname, @username, @password, @manager, @employeeid)", conn))
            {
                command.Parameters.AddWithValue("@fname", q.Fname);
                command.Parameters.AddWithValue("@lname", q.Lname);
                command.Parameters.AddWithValue("@username", q.Username);
                command.Parameters.AddWithValue("@password", q.Password);
                command.Parameters.AddWithValue("@manager", q.Manager);
                command.Parameters.AddWithValue("@employeeid", q.EmployeeID);
                conn.Open();
                bool ret = (await command.ExecuteNonQueryAsync()) == 1;

                conn.Close();
                return ret;
            }
        }//EoInsertNewUserAsync

        public async Task<bool> SubmitNewTicketAsync (Ticket t) //The Int thing must have been a carry over from the consoleapp program logic. Bool makes more sense than int here.
        {
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using SqlCommand command = new SqlCommand($"INSERT INTO Tickets VALUES (@amount, @description, @status, @ticketid, @employeeid)", conn);
            command.Parameters.AddWithValue("@amount", t.Amount);
            command.Parameters.AddWithValue("@description", t.Description);
            command.Parameters.AddWithValue("@status", t.Status);
            command.Parameters.AddWithValue("@ticketid", t.TicketID);
            command.Parameters.AddWithValue("@employeeid", t.EmployeeID);
            conn.Open();
            bool ret = (await command.ExecuteNonQueryAsync()) == 1;

            conn.Close();
            return ret;
        }//EoSubmitNewTicketAsync

        public async Task<bool?> IsSheManagerAsync(Guid employeeid)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using SqlCommand command = new SqlCommand($"SELECT Manager FROM Employees WHERE EmployeeID = @employeeid", conn);
            command.Parameters.AddWithValue("@employeeid", employeeid);
            conn.Open();
            SqlDataReader? ret = await command.ExecuteReaderAsync();
            if(ret.Read() && ret.GetBoolean(4))
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }//EoIsSheManagerAsync

        public async Task<List<Ticket>> PendingTicketsAsync(int status) //Are there pending tickets? Grab them using this
        {
            List<Ticket> ticketList = new List<Ticket>();
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using SqlCommand command = new SqlCommand($"SELECT * FROM Tickets WHERE Status = @status", conn);
            command.Parameters.AddWithValue("@status", status);
            conn.Open();
            SqlDataReader? ret = await command.ExecuteReaderAsync();
            while (ret.Read())
            {
                Ticket t = new Ticket(
                    ret.GetDecimal(0),
                    ret.GetString(1),
                    ret.GetInt32(2),
                    (Guid)ret[3],
                    (Guid)ret[4]
                    );
                    ticketList.Add(t);
            }
            conn.Close();

            return ticketList;
        }//EoPendingTicketsAsync

        /*public Task<Ticket?> PendingTicketsAsync(PendingDTO p)
        {
            throw new NotImplementedException();
        }*/

        public async Task<ProcessedTicketDto> ProcessTicketAsync(Guid ticketid, int status)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using SqlCommand command = new SqlCommand($"UPDATE Tickets SET Status = @s WHERE TicketID = @x AND Status = 0", conn); //Don't update tickets unless they are pending
            command.Parameters.AddWithValue("@s", status);
            command.Parameters.AddWithValue("@x", ticketid);
            conn.Open();
            int ret = await command.ExecuteNonQueryAsync(); //Pending = 0
            if(ret == 0)
            {
                conn.Close();
                ProcessedTicketDto ptd = await this.ProcessTicketIDAsync(ticketid);
                return ptd;
            }
            conn.Close();
            return null;
        }//EoProcessTicketAsync

        private async Task<ProcessedTicketDto> ProcessTicketIDAsync(Guid ticketid)
    {
        SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using (SqlCommand cmd = new SqlCommand($"UPDATE Tickets SET TicketID = @ticketid", conn));
        {
            command.Parameters.AddWithValue("@ticketid", ticketid);
            conn.Open();
            SqlDataReader? ret = await command.ExecuteReaderAsync();
            if (ret.Read())
            {
                ProcessedTicketDto t = new ProcessedTicketDto(
                ret.GetGuid(0),
                ret.GetString(1),
                ret.GetString(2),
                ret.GetInt32(3));
                conn.Close();
                return t;
            }
            conn.Close();
            return null;
        }
    }

        public async Task<int> UpdateUserNameAsync(Employee q)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using SqlCommand command = new SqlCommand($"UPDATE Employees SET Fname = @a, Lname = @b, Username = @c, Password = @d WHERE EmployeeID = @e ", conn);
            command.Parameters.AddWithValue("@a", q.Fname);
            command.Parameters.AddWithValue("@b", q.Lname);
            command.Parameters.AddWithValue("@c", q.Username);
            command.Parameters.AddWithValue("@d", q.Password);
            command.Parameters.AddWithValue("@e", q.EmployeeID);
            conn.Open();
            int ret = await command.ExecuteNonQueryAsync();
            conn.Close();
            return ret;
        }//EoUpdateUserNameAsync

        public async Task<Ticket?> GetTicketAsync(int employID)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using SqlCommand command = new SqlCommand($"SELECT * FROM Tickets WHERE EmployeeID = @employID;", conn);
            command.Parameters.AddWithValue("@employID", employID);
            conn.Open();
            SqlDataReader? ret = await command.ExecuteReaderAsync();

            if (ret.Read())
            {
                Ticket? t = null;
                t.TicketID = ret.GetGuid(0);
                t.Amount = ret.GetDecimal(1);
                t.Description = ret.GetString(2);
                t.Status = ret.GetInt32(3);
                t.EmployeeID = ret.GetGuid(4);
                conn.Close();
                return t;
            }
            else
            {
                conn.Close();
                return null;
            }
        }//EoGetTicketAsync
    }//EoC
}//EoN

       /* public async Task<Employee?> IsSheEmployeeAsync(string fname, string lname, bool manager)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT Top 1 EmployeeID, Fname, Lname, Manager FROM Employees WHERE Fname = @fname AND Lname = @lname AND Manager = @manager", conn))
            {
                command.Parameters.AddWithValue("@fname", fname);
                command.Parameters.AddWithValue("@lname", lname);
                command.Parameters.AddWithValue("@manager", manager);
                conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();

                if(ret.Read())
                {
                    Employee e = new Employee();
                    e.EmployeeID = ret.GetGuid(0);
                    e.Fname = ret.GetString(1);
                    e.Lname = ret.GetString(2);
                    e.Manager = ret.GetBoolean(5);
                    conn.Close();
                    return e;
                }
                else
                {
                    conn.Close();
                    return null;
                }
            }
        } */