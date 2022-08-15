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
            public static async Task Main(string[] args)
            {
                LoginSession loginsession = new LoginSession();
                Console.WriteLine("\t\tWelcome to the Employee Reimbursement System\n");
                Console.WriteLine("What is your username and password?");

                while (true)
                {
                    bool userInDb = false;

                    if (userInDb) 
                    {
                        Console.WriteLine($"Hello, {loginsession.GetUser")
                    }

                }
            }
        }
}



