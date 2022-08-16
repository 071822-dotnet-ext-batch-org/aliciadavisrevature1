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
        //private static readonly SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        public async Task<Employee?> ExistsUserNameAsync(string username, string passcode)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT Top 1 EmployeeID Username Password Fname Lname Manager FROM Employees WHERE Username = @username AND Password = @passcode", conn))
            {
                command.Parameters.AddWithValue("@username", username);//adding dynamic data will protect against SQL Injection
                command.Parameters.AddWithValue("@passcode", passcode);
                conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                if(ret.Read())
                {
                    Employee c = new Employee();
                    c.Username = ret.GetString(1);
                    c.Password = ret.GetString(2);
                    conn.Close();
                    return c;
                }
                else
                {
                    conn.Close();
                    return null;
                }
            }
        }

        public async Task<int> InsertNewUserNameAsync(Employee c)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"INSERT INTO Employees VALUES (@employID, @fname, @lname, @username, @passcode, @manager)", conn))
            {
                command.Parameters.AddWithValue("@username", c.Username);
                command.Parameters.AddWithValue("@passcode", c.Password);
                command.Parameters.AddWithValue("@employID", c.EmployeeID);
                command.Parameters.AddWithValue("@fname", c.Fname);
                command.Parameters.AddWithValue("@lname", c.Lname);
                command.Parameters.AddWithValue("@manager", c.Manager);
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
        }

        public async Task<Employee?> IsSheManagerAsync(bool True)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT Top 1 EmployeeID, Fname, Lname, Manager FROM Employees WHERE Manager = @manager", conn))
            {
                command.Parameters.AddWithValue("@manager", true);
                conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();

                if(ret.Read())
                {
                    Employee e = new Employee();
                    e.EmployeeID = ret.GetInt32(0);
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
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Tickets WHERE EmployeeID = @employID;", conn))
            {
                command.Parameters.AddWithValue("@employID", employID);
                conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();

                if (ret.Read())
                {
                    Ticket t = new Ticket();
                    t.TicketID = ret.GetInt32(0);
                    t.Amount = ret.GetDouble(1);
                    t.Description = ret.GetString(2);
                    t.Status = ret.GetInt32(3);
                    t.EmployeeID = ret.GetInt32(4);
                    conn.Close();
                    return t;
                }
                else
                {
                    conn.Close();
                    return null;
                }
            }
         }

        public async Task<int> UpdateTicketAsync(Ticket t)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"UPDATE Tickets SET Status = @s WHERE TicketID = @x AND Status = 0", conn))
            {
                command.Parameters.AddWithValue("@s", t.Status);
                command.Parameters.AddWithValue("@x", t.TicketID);
                conn.Open();
                int ret = await command.ExecuteNonQueryAsync();
                conn.Close();
                return ret;
            }
        }

        public async Task<int> SubmitTicketAsync (Ticket t)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"INSERT INTO Tickets VALUES (@ticketID @amount @description @status @employID)", conn))
            {
                command.Parameters.AddWithValue("@ticketID", t.TicketID);
                command.Parameters.AddWithValue("@amount", t.Amount);
                command.Parameters.AddWithValue("@description", t.Description);
                command.Parameters.AddWithValue("@status", t.Status);
                command.Parameters.AddWithValue("@employID", t.EmployeeID);
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
        }
    }//EoC
}//EoN

       /* public async Task<Employee?> IsSheEmployeeAsync(string fname, string lname, bool manager)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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