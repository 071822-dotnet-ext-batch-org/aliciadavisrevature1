using System.Net;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BusinessLayer;
using Models;

namespace EmployeeReimbursementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeReimbursementController : ControllerBase
    {
        private LoginSession _loginsession = new LoginSession();
       //private readonly LoginSession _loginsession;
       /*public EmployeeReimbursementController(LoginSession loginsession)
        {
            this._loginsession = loginsession;
        }*/

        [HttpPost("Logon")] //Check the credentials
        public async Task <ActionResult> LogonAsync(UserDTO Logon)
        {
         if (ModelState.IsValid)//Model Validation: was it possible to bind incoming values to UserDTO?
            {
                return /*Ok does not return*/Accepted(await this._loginsession.LogonAsync(Logon.username, Logon.password)); //returns status code 200
            }
        else
            {
            return NotFound("No logon credentials found"); //Flipped return methods so await comes first
            }
        }

        [HttpPost("RegisterAccount")] //Create new employee account in directory
        public async Task<ActionResult> RegisterAccountAsync(Employee q)
        {
            var isSuccess = await this._loginsession.RegisterAccountAsync(q);
            if (isSuccess) 
                {
                    return Created($"Welcome /Employee/{q.Fname} /Employee/{q.Lname}", q); //Created will need at least one argument. Can personlize messages in this manner. Difficulty using composite format though 
                }
            return NotFound("Something went wrong. Did you fill in all the fields?");
        }

       /* [HttpGet("PendingTicketsAsync/{type}")] //Get the tickets with pending status
        public async Task <ActionResult<List<Ticket>>>PendingTicketsAsync(int type)
        {
            List<Ticket> ticketList = await this._loginsession.PendingTicketsAsync(type);
            return Ok(ticketList); //returns status code 200
        }*/


    }//EoC
}//EoN