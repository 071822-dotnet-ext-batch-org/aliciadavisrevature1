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
        public async Task <ActionResult> LogonAsync(UserDTO Logon) //User data transfer object to carry data between process (my logon methods).
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
            var isSuccess = await this._loginsession.RegisterAccountAsync(q); //"Does exactly what it says on the tin" Identity result method isSuccess will "assert" that the result looking for succeeded. 
            if (isSuccess) 
                {
                    return Created($"Welcome /Employee/{q.Fname} /Employee/{q.Lname}", q); //Created will need at least one argument. Can personlize messages in this manner. Difficulty using composite format though 
                }
            return NotFound("Something went wrong. Did you fill in all the fields, correctly?");
        }

        [HttpPost("SubmitTicket")]
        public async Task<ActionResult> SubmitTicketAsync(Ticket t)
        {
            var isSuccess = await this._loginsession.SubmitTicketAsync(t);
            if (isSuccess)
            {
                return Created($"Your ticket request has been submitted for review. It is /Ticket/{t.Status}", t); //Created will need at least one argument. Can personlize messages in this manner.
            }
            return NotFound("Something went wrong. Did you fill in all the fields, correctly?");
        }

        [HttpPut("ProcessPendingTickets")]//PUT will update/replace not safe but is idempotent (multiple requests will have same outcome but not necessarily same response from server). PATCH will update/modify and is not safe nor idempotent. PUT more fault tolerant than PATCH.
        public async Task<ActionResult> ProcessPendingTicketsAsync(PendingDTO p) //Pending data transfer object to carry data between process (my pending ticket methods)
        {
            var isSuccess = await this._loginsession.ProcessPendingTicketsAsync(p);
            if (isSuccess)
            {
                return Ok($"The pending ticket request status has been updated");
            }
            return NotFound("Something went wrong. Did you select the correct code?");
        }

       /* [HttpGet("PendingTicketsAsync/{type}")] //Get the tickets with pending status
        public async Task <ActionResult<List<Ticket>>>PendingTicketsAsync(int type)
        {
            List<Ticket> ticketList = await this._loginsession.PendingTicketsAsync(type);
            return Ok(ticketList); //returns status code 200
        }*/


    }//EoC
}//EoN