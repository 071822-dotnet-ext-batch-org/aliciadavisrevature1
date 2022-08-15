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
        public async Task<bool> ExistsEmployeeAsync(Guid UserNameID)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT Top 1 UserNameID FROM Credentials WHERE UserNameID =@x", conn))
            {
                command.Parameters.AddWithValue("@x", UserNameID);//adding dynamic data will protect against SQL Injection
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
        
        public async Task<int> InsertNewUserNameAsync(Credentials q)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"INSERT INTO Credentials VALUES (@userID, @user, @passcode)", conn))
            {
                command.Parameters.AddWithValue("@user", q.UserName);
                command.Parameters.AddWithValue("@passcode", q.Password);
                command.Parameters.AddWithValue("@userID", q.UserNameID);
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
        
        public async Task<Employee?> IsSheManagerAsync(Guid username)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:alicia-davis.database.windows.net,1433;Initial Catalog=Expense Reimbursement System P1;Persist Security Info=False;User ID=aliciadavisrevature;Password=Thisisonly1test;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT Top 1 EmployeeID, Fname, Lname, Manager FROM Employees WHERE UserNameID = @username", conn))
            {
                command.Parameters.AddWithValue("@username", username);
                conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();

                if(ret.Read())
                {
                    Employee q = new Employee();
                    q.EmployeeID = ret.GetGuid(0);
                    q.Fname = ret.GetString(1);
                    q.Lname = ret.GetString(2);
                    q.Manager = ret.GetBoolean(5);
                    conn.Close();
                    return q;
                }
                else
                {
                    conn.Close();
                    return null;
                }
            }
        }
         
    }//EoC
}//EoN