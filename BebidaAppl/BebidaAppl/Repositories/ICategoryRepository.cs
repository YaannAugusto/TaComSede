using BebidaAppl.Models;

namespace BebidaAppl.Repositories
{
    public interface ICategoryRepository
    {
        //um contrato na qual retorna todos os objetos do tipo Categoria
        IEnumerable<Category> Categories { get;}
    }
}
