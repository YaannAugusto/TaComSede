using BebidaAppl.Context;
using BebidaAppl.Models;
using Microsoft.EntityFrameworkCore;

namespace BebidaAppl.Repositories.Interfaces
{
    public class BrandRepository : IBrandRepository
    {
        private readonly AppDbContext context;

        public BrandRepository(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<Brand> Brands => context.Brands.Include(p => p.Drinks);
    }
}
