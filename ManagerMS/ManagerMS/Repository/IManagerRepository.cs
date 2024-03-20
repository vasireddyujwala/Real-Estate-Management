using ManagerMS.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ManagerMS.Repository
{
    public interface IManagerRepository
    {
        Task<string> AssignExecutive(CustomerExecutiveModel assignExecutiveModel);
        Task<int> CreateExecutive(Executive executive);
        PropertyResponse CreateProperties(Properties properties);
        Task<HttpResponseMessage> GetAllCusomterById(int customerId);
        Task<HttpResponseMessage> GetAllCusomters();
        List<Executive> GetAllExecutive();
        Task<HttpResponseMessage> GetAllProperties();
    }
}