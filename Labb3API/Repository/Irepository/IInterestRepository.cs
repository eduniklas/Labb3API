using APILabb.Models;
using System.Linq.Expressions;

namespace APILabb.Repository.Irepository
{
    public interface IInterestRepository
    {
        Task<List<Interest>> GetAllAsync(Expression<Func<Interest, bool>>? filter = null);
        Task<Interest> GetAsync(Expression<Func<Interest, bool>>? filter = null, bool tracked = true);
        Task CreateAsync(Interest entity);
        Task RemoveAsync(Interest entity);
        Task<Interest> UpdateAsync(Interest entity);
        Task SaveAsync();
    }
}
