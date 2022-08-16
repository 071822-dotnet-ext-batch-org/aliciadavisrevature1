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

                    Console.WriteLine("Enter a username and password");
                    bool userInDb = false;

                    if (userInDb) 
                    {
                        Console.WriteLine($"Hello, {loginsession.GetE1().Fname} {loginsession.GetE1().Lname}.");
                    }
                    else
                    {
                        Console.WriteLine($"Hello, {loginsession.GetE1().Fname} {loginsession.GetE1().Lname}. The username, {loginsession.GetC1().UserName}, is your new login.");
                    }

                }//EofFirstWhileLoop
            }
        }
}



