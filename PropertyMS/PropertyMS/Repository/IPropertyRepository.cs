using PropertyMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyMS.Repository
{
    public interface IPropertyRepository
    {
        Task<int> AddcreateProperty(Properties propertyModel);
        List<Properties> GetAllProperty();
        Task<Properties> GetPropertyIdAsync(int propertyId);
    }
}