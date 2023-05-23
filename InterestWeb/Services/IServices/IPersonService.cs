using InterestWeb.Models.DTO;

namespace InterestWeb.Services.IServices
{
    public interface IPersonService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(PersonCreateDto dto);
        Task<T> UpdateAsync<T>(PersonUpdateDto dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
