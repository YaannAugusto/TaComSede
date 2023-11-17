using System.Diagnostics;
using BebidaAppl.Models;
using BebidaAppl.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BebidaAppl.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger ILogger<HomeController> logger,; 
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDrinkRepository _drinkRepository;
        

       
        public HomeController(ICategoryRepository categoryRepository, IDrinkRepository drinkRepository)
        {
            _categoryRepository = categoryRepository;
            _drinkRepository = drinkRepository;
            //_logger = logger;
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}