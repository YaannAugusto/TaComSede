using BebidaAppl.Context;
using BebidaAppl.Models;
using Microsoft.EntityFrameworkCore;

namespace BebidaAppl.Repositories.Interfaces
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly AppDbContext context;

        public DrinkRepository(AppDbContext _context)
        {
            context = _context;
        }

        public IEnumerable<Drink> Drinks => context.Drinks.Include(p => p.Brand).Include(p => p.Category);
        
        IEnumerable<Drink> IDrinkRepository.DrinksPrefer => context.Drinks.Where(p => p.IsBebidaPrefer).Include(p => p.Category);

        Drink IDrinkRepository.GetADrinkById(int BebidaId) => context.Drinks.FirstOrDefault(p => p.BebidaId == BebidaId);
        
    }
}
