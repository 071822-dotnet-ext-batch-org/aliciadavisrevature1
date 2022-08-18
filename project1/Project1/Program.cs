using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Models;

namespace Project1
{
        public class Program
        {
            public static async Task Main(string[] args)//Task return type is void
            {
                LoginSession loginsession = new LoginSession();//Maintain DB
                Console.WriteLine("\t\tWelcome to the Employee Reimbursement System\n");

                //This loop begins the login session
                while (true)
                {
                    //Create a new login session within LoginSession Class instance
                    await loginsession.IsSheEmployeeAsync();

                    //Get login credentials
                    Console.WriteLine("Enter a username and password");
                    bool userInDb = false;

                    if (userInDb) //If user is in the DB
                    {
                        Console.WriteLine($"Hello, {loginsession.GetE1().Fname} {loginsession.GetE1().Lname}.");
                    }
                    else //If user is not in DB
                    {
                        Console.WriteLine("Enter your First and Last Names");
                        Console.WriteLine($"Hello, {loginsession.GetE1().Fname} {loginsession.GetE1().Lname}. The username, {loginsession.GetC1().UserName}, is your new login.");
                    }

                    //loop for reimbursement system
                    bool IsSheManagerAsync = false;
                    if(IsSheManagerAsync == true)
                    {
                        Console.WriteLine($"All Reimbursement Tickets {Get")
                        Console.WriteLine($"Update {IStatus.Status.Pending} reimbursement tickets. 1 for Approved or 2 for Denied.}")
                        if ()
                        {
                            
                        }
                    }

                }//EofFirstWhileLoop
            }
        }
}



