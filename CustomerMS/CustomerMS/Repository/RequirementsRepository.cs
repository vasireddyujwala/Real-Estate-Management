using CustomerMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMS.Repository
{
    public class RequirementsRepository : IRequirementsRepository
    {
        private readonly CustomerMSContext _context;

        public RequirementsRepository(CustomerMSContext context)
        {
            _context = context;
        }

        public int PropertyType { get; private set; }

        public async Task<List<Requirement>> GetPropertyAsync()
        {
            var DataRequirement = await _context.Requirements.Select(x => new Requirement()
            {
                Id = x.Id,
                PropertyType = x.PropertyType,
                Budget = x.Budget,
                Locality = x.Locality,

            }).ToListAsync();
            return DataRequirement;
        }
    }
}
