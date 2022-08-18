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
       private readonly LoginSession _businessLayer;
       public EmployeeReimbursementController()
        {
            this._businessLayer = new LoginSession();
        }


        [HttpGet("PendingTicketsAsync/{type}")] //Get the tickets with pending status
        public async Task <ActionResult<List<Ticket>>>PendingTicketsAsync(int type)
        {
            List<Ticket> ticketList = await this._businessLayer.PendingTicketsAsync(type);
            return Ok(ticketList);//returns status code 200
        }


    }//EoC
}//EoN