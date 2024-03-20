using ManagerMS.DbContexts;
using ManagerMS.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ManagerMS.Repository
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly ILogger _logger;
        private IManagerMSContext _dbcontext;
        string apiurl = "https://localhost:5004/";
        public ManagerRepository(IManagerMSContext dbcontext, ILogger<ManagerRepository> logger)
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }

        public async Task<int> CreateExecutive(Executive executive)
        {
            try
            {
                _logger.LogError("ManagerRepository- CreateExecutive Start");
                _dbcontext.Executives.Add(executive);
                await _dbcontext.SaveChanges();
                _logger.LogError("ManagerRepository- CreateExecutive end");
                return executive.ExecutiveId;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in CreateExecutive:-", ex.Message);
                throw;
            }
        }

        public PropertyResponse CreateProperties(Properties properties)
        {

            using (var _client = new HttpClient())
            {
                _logger.LogError("ManagerRepository- CreateProperties Start");
                _client.BaseAddress = new Uri(apiurl);
                var stringPayload = JsonConvert.SerializeObject(properties);
                var payload = new StringContent(stringPayload, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = _client.PostAsync("api/Property/createProperty", payload).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    _logger.LogError("ManagerRepository- CreateProperties end");
                    return new PropertyResponse { Message = "Property Created Successfull", Success = true };
                }
                _logger.LogError("Error occured in CreateProperties.");
                return new PropertyResponse { Message = "Something might be wrong", Success = false };
            }
        }

        public async Task<HttpResponseMessage> GetAllProperties()
        {
            try
            {
                _logger.LogError("ManagerRepository- GetAllProperties Start");
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiurl);
                    HttpResponseMessage responseMessage = await client.GetAsync($"api/Property/GetAllProperty");
                    _logger.LogError("ManagerRepository- GetAllProperties end");
                    return responseMessage;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in GetAllProperties:-", ex.Message);
                throw;
            }
        }

        public async Task<HttpResponseMessage> GetAllCusomters()
        {
            try
            {
                _logger.LogError("ManagerRepository- GetAllCusomters Start");
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiurl);
                    HttpResponseMessage responseMessage = await client.GetAsync($"api/Customer/GetAllCustomer");
                    _logger.LogError("ManagerRepository- GetAllCusomters end");
                    return responseMessage;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in GetAllCusomters:-", ex.Message);
                throw;
            }
        }

        public async Task<HttpResponseMessage> GetAllCusomterById(int customerId)
        {
            try
            {
                _logger.LogError("ManagerRepository- GetAllCusomterById Start");
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiurl);
                    HttpResponseMessage responseMessage = await client.GetAsync($"api/Customer/GetAllCustomer/customerId");
                    _logger.LogError("ManagerRepository- GetAllCusomterById end");
                    return responseMessage;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in GetAllCusomterById:-", ex.Message);
                throw;
            }
        }

        public List<Executive> GetAllExecutive()
        {
            try
            {
                _logger.LogError("ManagerRepository- GetAllExecutive Start");
                var executives = _dbcontext.Executives.ToList<Executive>();
                _logger.LogError("ManagerRepository- GetAllExecutive end");
                return executives;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in GetAllExecutive:-", ex.Message);
                throw;
            }
        }

        public async Task<string> AssignExecutive(CustomerExecutiveModel assignExecutiveModel)
        {
            try
            {
                _logger.LogError("ManagerRepository- AssignExecutive Start");
                _dbcontext.AssignExecutives.Add(assignExecutiveModel);
                await _dbcontext.SaveChanges();
                _logger.LogError("ManagerRepository- AssignExecutive end");
                return "Success";
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in AssignExecutive:-", ex.Message);
                throw;
            }
        }
    }
}
