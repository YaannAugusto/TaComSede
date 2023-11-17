using BebidaAppl.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BebidaAppl.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController (ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult AllCategory()
        {
            var categories = _categoryRepository.Categories;
            return View(categories);
        }
    }
}
