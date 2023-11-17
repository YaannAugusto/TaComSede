using BebidaAppl.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BebidaAppl.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandRepository _brandRepository;

        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public IActionResult AllBrands()
        {
            var allBrand = _brandRepository.Brands;
            return View(allBrand);
        }
    }
}
