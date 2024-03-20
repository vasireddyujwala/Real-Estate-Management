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
using Microsoft.AspNetCore.Authorization;

namespace ManagerMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    //[Authorize(Roles = "Manager")]
    public class ManagersController : ControllerBase
    {
        private readonly ManagerMSContext _context;

        public ManagersController(ManagerMSContext context)
        {
            _context = context;
        }

        // GET: api/Managers
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Executive>>> GetExecutives()
        {
            return await _context.Executives.ToListAsync();
        }

        // GET: api/Managers/5
        [HttpGet("[action]/{locality}")]
        public async Task<ActionResult<IEnumerable<Executive>>> GetExecutive(string locality)
        {
            List<Executive> executive = await _context.Executives.ToListAsync();
            List<Executive> filter = executive.FindAll(obj => obj.Locality == locality);

            if (executive == null)
            {
                return NotFound();
            }

            return filter;
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Executive>> GetExecutiveById(int id)
        {
            var executive = await _context.Executives.FindAsync(id);

            if (executive == null)
            {
                return NotFound();
            }

            return executive;
        }
        [HttpGet("[action]/{name}")]
        public async Task<ActionResult<Executive>> GetExecutiveByName(string name)
        {
            List<Executive> executives = await _context.Executives.ToListAsync();
            var executive = executives.Find(obj => obj.Name == name);

            if (executive == null)
            {
                return NotFound();
            }

            return executive;
        }



        // POST: api/Managers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Executive>> PostExecutive(Executive executive)
        {
            _context.Executives.Add(executive);
            await _context.SaveChangesAsync();

            return Ok(executive);
        }
    }
}
