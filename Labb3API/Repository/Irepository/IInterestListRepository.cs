using APILabb.Models;
using System.Linq.Expressions;

namespace APILabb.Repository.Irepository
{
    public interface IInterestListRepository 
    {
        Task<List<InterestList>> GetAllAsync(Expression<Func<InterestList, bool>>? filter = null);
        Task<InterestList> GetAsync(Expression<Func<InterestList, bool>>? filter = null, bool tracked = true);
        Task CreateAsync(InterestList entity);
        Task RemoveAsync(InterestList entity);
        Task<InterestList> UpdateAsync(InterestList entity);
        Task SaveAsync();
    }
}
