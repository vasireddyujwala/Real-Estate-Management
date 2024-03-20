using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManagerMS.DbContexts;
using ManagerMS.Models;
using Microsoft.AspNetCore.Cors;

namespace ManagerMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class CustomerExecutiveController : ControllerBase
    {
        private readonly ManagerMSContext _context;

        public CustomerExecutiveController(ManagerMSContext context)
        {
            _context = context;
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<IEnumerable<CustomerExecutiveModel>>> GetCustomers(int id)
        {
            List<CustomerExecutiveModel> executive = await _context.AssignExecutives.ToListAsync();

            var filter = executive.FindAll(obj => obj.ExecutiveId == id);
            if (filter == null)
            {
                return NotFound();
            }

            return filter;
        }


        [HttpPost]
        public async Task<ActionResult<CustomerExecutiveModel>> PostCustomerExecutiveModel(CustomerExecutiveModel customerExecutiveModel)
        {
            _context.AssignExecutives.Add(customerExecutiveModel);
            await _context.SaveChangesAsync();

            return Ok(customerExecutiveModel);
        }


    }
}
