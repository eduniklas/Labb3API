using Interest_Utility;
using InterestWeb.Models;
using InterestWeb.Models.DTO;
using InterestWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace InterestWeb.Services
{
    public class InterestService : BaseService, IInterestService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string _interestUrl;
        public InterestService(IHttpClientFactory clientFactory, IConfiguration configuration) :base(clientFactory)
        {
            _clientFactory = clientFactory;
            _interestUrl = configuration.GetValue<string>("ServiceUrls:InterestApi");
        }
        public Task<T> CreateAsync<T>(InterestCreateDto dto)
        {
            return SendAsync<T>(apiRequest: new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                ApiUrl = _interestUrl + "/api/interestApi/"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(apiRequest: new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                ApiUrl = _interestUrl + "/api/interestApi/" + id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(apiRequest: new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = _interestUrl + "/api/interestApi/"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(apiRequest: new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = _interestUrl + "/api/interestApi/" + id
            });
        }

        public Task<T> UpdateAsync<T>(InterestUpdateDto dto)
        {
            return SendAsync<T>(apiRequest: new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                ApiUrl = _interestUrl + "/api/interestApi/" + dto.InterestId
            });
        }
    }
}
