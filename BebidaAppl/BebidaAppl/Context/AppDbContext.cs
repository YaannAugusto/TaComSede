using BebidaAppl.Models;
using Microsoft.EntityFrameworkCore;

namespace BebidaAppl.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }
    }
}
