using InterestWeb.Models.DTO;

namespace InterestWeb.Services.IServices
{
    public interface IInterestService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(InterestCreateDto dto);
        Task<T> UpdateAsync<T>(InterestUpdateDto dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
