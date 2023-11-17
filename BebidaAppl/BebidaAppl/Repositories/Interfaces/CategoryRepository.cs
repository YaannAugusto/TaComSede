using BebidaAppl.Context;
using BebidaAppl.Models;
using Microsoft.EntityFrameworkCore;

namespace BebidaAppl.Repositories.Interfaces
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;

        public CategoryRepository(AppDbContext _context)
        {
            this.context = _context;
        }

        public IEnumerable<Category> Categories => context.Categories.Include(p => p.Drinks);
    }
}
