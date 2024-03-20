using CustomerMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerMS.Repository
{
    public interface IRequirementsRepository
    {

        Task<List<Requirement>> GetPropertyAsync();
    }
}