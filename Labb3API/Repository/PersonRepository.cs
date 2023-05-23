using APILabb.Data;
using APILabb.Models;
using APILabb.Repository.Irepository;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace APILabb.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Person entity)
        {
            
            await _context.Persons.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<List<Person>> GetAllAsync(Expression<Func<Person, bool>>? filter = null)
        {
            IQueryable<Person> temp = _context.Persons.Include(i=>i.Interests);
            if (filter != null)
            {
                temp = temp.Where(filter);
            }
            return await temp.ToListAsync();
        }

        public async Task<Person> GetAsync(Expression<Func<Person, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<Person> temp = _context.Persons;
            if (!tracked == true)
            {
                temp = temp.AsNoTracking();
            }
            if (filter != null)
            {
                temp = temp.Where(filter);
            }
            return await temp.Include(i=>i.Interests).FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(Person entity)
        {
            _context.Persons.Remove(entity);
            await SaveAsync();
        }
        

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Person> UpdateAsync(Person entity)
        {
            _context.Persons.Update(entity);
            await SaveAsync();
            return entity;
        }
    }
}
