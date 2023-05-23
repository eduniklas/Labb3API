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
    public class InterestRepository : IInterestRepository
    {
        private readonly ApplicationDbContext _context;
        public InterestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Interest entity)
        {
            
            await _context.Interests.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<List<Interest>> GetAllAsync(Expression<Func<Interest, bool>>? filter = null)
        {
            IQueryable<Interest> temp = _context.Interests.Include(p=>p.Persons);
            if (filter != null)
            {
                temp = temp.Where(filter);
            }
            return await temp.ToListAsync();
        }

        public async Task<Interest> GetAsync(Expression<Func<Interest, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<Interest> temp = _context.Interests;
            if (!tracked == true)
            {
                temp = temp.AsNoTracking();
            }
            if (filter != null)
            {
                temp = temp.Where(filter);
            }
            return await temp.FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(Interest entity)
        {
            _context.Interests.Remove(entity);
            await SaveAsync();
        }
        

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Interest> UpdateAsync(Interest entity)
        {
            _context.Interests.Update(entity);
            await SaveAsync();
            return entity;
        }
    }
}
