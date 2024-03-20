using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyMS.DbContexts;
using PropertyMS.Models;

namespace PropertyMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly PropertyMSContext _context;

        public PropertiesController(PropertyMSContext context)
        {
            _context = context;
        }

        // GET: api/Properties
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Properties>>> GetAllProperty()
        {
            return await _context.Properties.ToListAsync();
        }

        // GET: api/Properties/5
        [HttpGet("[action]/{propertyId}")]
        public async Task<ActionResult<Properties>> GetPropertiesInfoById(int propertyId)
        {
            var properties = await _context.Properties.FindAsync(propertyId);

            if (properties == null)
            {
                return NotFound();
            }

            return properties;
        }

        [HttpGet("[action]/{locality}")]
        public async Task<ActionResult<IEnumerable<Properties>>> GetPropertiesInfoByLocality(string locality)
        {
            List<Properties> properties = await _context.Properties.ToListAsync();
            List<Properties> filter = properties.FindAll(obj => obj.Locality == locality);

            if (filter == null)
            {
                return NotFound();
            }

            return filter;
        }



        // POST: api/Properties
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("[action]")]
        public async Task<ActionResult<Properties>> CreateProperty(Properties properties)
        {
            _context.Properties.Add(properties);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProperties", new { id = properties.PropertyId }, properties);
        }
    }
}
