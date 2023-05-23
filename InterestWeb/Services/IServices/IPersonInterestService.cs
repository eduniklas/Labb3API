using InterestWeb.Models.DTO;

namespace InterestWeb.Services.IServices
{
    public interface IPersonInterestService
    {
        //Task<T> GetAllAsync<T>();
        Task<T> GetAllAsync<T>(int id);
        Task<T> GetAllLinkAsync<T>(int id);
        //Task<T> GetAsync<T>(int id);
        //Task<T> CreateAsync<T>(InterestListCreateDto dto);
        //Task<T> UpdateAsync<T>(InterestListUpdateDto dto);
        //Task<T> DeleteAsync<T>(int id);
    }
}
