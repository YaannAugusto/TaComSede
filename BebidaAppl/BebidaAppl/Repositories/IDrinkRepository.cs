using BebidaAppl.Models;

namespace BebidaAppl.Repositories
{
    public interface IDrinkRepository
    {
        //retorna uma coleção de objetos do tipo Drinks
        IEnumerable<Drink> Drinks { get; }

        //retorna uma coleção de objetos do tipo Drinks com um filtro de somente os preferidos
        IEnumerable<Drink> DrinksPrefer { get; }

        //retona uma bebida baseada no id desejado
        Drink GetADrinkById(int BebidaId);

    }
}
