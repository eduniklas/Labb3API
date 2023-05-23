using APILabb.Data;
using APILabb.Models;
using APILabb.Repository.Irepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace APILabb.Repository
{
    public class InterestListRepository : IInterestListRepository
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<InterestList> dbset;

        public InterestListRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(InterestList entity)
        {    
            await _context.InterestLists.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<List<InterestList>> GetAllAsync(Expression<Func<InterestList, bool>> filter = null)
        {
            IQueryable<InterestList> temp = _context.InterestLists;
            if (filter != null)
            {
                temp = temp.Where(filter);
            }
            return await temp.Include(p => p.Person).Include(p => p.Interest).OrderBy(n=>n.FK_PersonId).Where(p => p.Person.PersonId == p.FK_PersonId).ToListAsync();
        }

        public async Task<InterestList> GetAsync(Expression<Func<InterestList, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<InterestList> temp = _context.InterestLists.Include(p => p.Person).Include(p => p.Interest);
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

        public async Task RemoveAsync(InterestList entity)
        {
            _context.InterestLists.Remove(entity);
            await SaveAsync();
        }
        

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<InterestList> UpdateAsync(InterestList entity)
        {
            _context.InterestLists.Update(entity);
            await SaveAsync();
            return entity;
        }
    }
}
