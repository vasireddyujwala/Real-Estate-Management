using Microsoft.EntityFrameworkCore;
using PropertyMS.DbContexts;
using PropertyMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyMS.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly IPropertyMSContext _context;

        public PropertyRepository(IPropertyMSContext context)
        {
            _context = context;
        }

        public async Task<Properties> GetPropertyIdAsync(int propertyId)
        {
            var PropertyDetails = await _context.Properties.Where(x => x.PropertyId == propertyId).Select(x => new Properties()
            {
                PropertyId = x.PropertyId,
                PropertyType = x.PropertyType,
                Budget = x.Budget,
                Locality = x.Locality,

            }).FirstOrDefaultAsync();
            return PropertyDetails;

        }
        //HTTP Post code
        public async Task<int> AddcreateProperty(Properties propertyModel)
        {
            var Data = new Properties()
            {
                PropertyId = propertyModel.PropertyId,
                Budget = propertyModel.Budget,
                Locality = propertyModel.Locality,
                PropertyType = propertyModel.PropertyType,
            };
            _context.Properties.Add(Data);
            await _context.SaveChanges();
            return Data.PropertyId;
        }

        public List<Properties> GetAllProperty()
        {
            return _context.Properties.ToList();
        }
    }
}
