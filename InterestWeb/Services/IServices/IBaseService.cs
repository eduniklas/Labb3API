using InterestWeb.Models;

namespace InterestWeb.Services.IServices
{
    public interface IBaseService
    {
        ApiResponse responseModel { get; set; }

        Task<T> SendAsync<T> (ApiRequest apiRequest);
    }
}
