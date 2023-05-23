using InterestWeb.Models.DTO;

namespace InterestWeb.Services.IServices
{
    public interface IInterestListService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(InterestListCreateDto dto);
        Task<T> UpdateAsync<T>(InterestListUpdateDto dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
