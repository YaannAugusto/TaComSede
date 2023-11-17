using BebidaAppl.Models;

namespace BebidaAppl.ViewModels
{
    public class DrinkViewModel
    {
        public IEnumerable<Drink> Drinks { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
    }
}
