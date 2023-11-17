using BebidaAppl.Models;

namespace BebidaAppl.Repositories
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> Brands { get;  }
    }
}
