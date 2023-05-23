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
    public class PersonInterestRepository : IPersonInterestRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonInterestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<InterestList>> GetAllAsync(Expression<Func<InterestList, bool>> filter = null)
        {
            IQueryable<InterestList> temp = _context.InterestLists.Include(p => p.Person).Include(p => p.Interest);
            if (filter != null)
            {
                temp = temp.Where(filter);
            }
            return await temp.OrderBy(n=>n.InterestListId).ToListAsync();
        }
    }
}
