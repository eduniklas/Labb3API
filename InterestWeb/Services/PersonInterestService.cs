using Interest_Utility;
using InterestWeb.Models;
using InterestWeb.Models.DTO;
using InterestWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace InterestWeb.Services
{
    public class PersonInterestService : BaseService, IPersonInterestService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string _interestUrl;
        public PersonInterestService(IHttpClientFactory clientFactory, IConfiguration configuration) :base(clientFactory)
        {
            _clientFactory = clientFactory;
            _interestUrl = configuration.GetValue<string>("ServiceUrls:InterestApi");
        }
        
        public Task<T> GetAllAsync<T>(int id)
        {
            return SendAsync<T>(apiRequest: new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = _interestUrl + "/api/personInterestApi/" + id
            });
        }
        public Task<T> GetAllLinkAsync<T>(int id)
        {
            return SendAsync<T>(apiRequest: new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = _interestUrl + "/api/personInterestApi/" + id
            });
        }
    }
}
