using APILabb.Models;
using System.Linq.Expressions;

namespace APILabb.Repository.Irepository
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllAsync(Expression<Func<Person, bool>>? filter = null);
        Task<Person> GetAsync(Expression<Func<Person, bool>>? filter = null, bool tracked = true);
        Task CreateAsync(Person entity);
        Task RemoveAsync(Person entity);
        Task<Person> UpdateAsync(Person entity);
        Task SaveAsync();
    }
}
