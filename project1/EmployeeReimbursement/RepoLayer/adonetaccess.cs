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
        }

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
        }

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
        }
        public async Task<List<Ticket>> PendingTicketsAsync(int type)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Tickeets WHERE Status = @status", conn))
            {
                command.Parameters.AddWithValue("@status", type);
                conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                List<Ticket> tList = new List<Ticket>();
                while(ret.Read())
                {
                    Ticket t = new Ticket(ret.GetDecimal(1), ret.GetString(2), ret.GetInt32(3), (Guid)ret[4], (Guid)ret[5]);
                    tList.Add(t);
                }
                return tList;
            }
        }

        public async Task<Employee?> IsSheManagerAsync(bool True)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT Top 1 EmployeeID, Fname, Lname, Manager FROM Employees WHERE Manager = @manager", conn))
            {
                command.Parameters.AddWithValue("@manager", true);
                conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();

                if(ret.Read())
                {
                    Employee? e = null;
                    e.EmployeeID = ret.GetGuid(0);
                    e.Fname = ret.GetString(1);
                    e.Lname = ret.GetString(2);
                    e.Manager = ret.GetBoolean(3);
                    conn.Close();
                    return e;
                }
                else
                {
                    conn.Close();
                    return null;
                }
            }
        }

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
        }

        public async Task<int> UpdateTicketAsync(Ticket t)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using SqlCommand command = new SqlCommand($"UPDATE Tickets SET Status = @s WHERE TicketID = @x AND Status = 0", conn);
            command.Parameters.AddWithValue("@s", t.Status);
            command.Parameters.AddWithValue("@x", t.TicketID);
            conn.Open();
            int ret = await command.ExecuteNonQueryAsync();
            conn.Close();
            return ret;
        }

        public async Task<int> SubmitTicketAsync (Ticket t)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using SqlCommand command = new SqlCommand($"INSERT INTO Tickets VALUES (@ticketid @amount @description @status @employeeid)", conn);
            command.Parameters.AddWithValue("@ticketid", t.TicketID);
            command.Parameters.AddWithValue("@amount", t.Amount);
            command.Parameters.AddWithValue("@description", t.Description);
            command.Parameters.AddWithValue("@status", t.Status);
            command.Parameters.AddWithValue("@employeeid", t.EmployeeID);
            conn.Open();
            int ret = await command.ExecuteNonQueryAsync();

            if (ret == 1)
            {
                conn.Close();
                return ret;
            }
            else
            {
                conn.Close();
                return ret;
            }
        }
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