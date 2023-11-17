using BebidaAppl.Models;
using BebidaAppl.Repositories;
using BebidaAppl.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BebidaAppl.Controllers
{
    public class BebidaController : Controller
    {
        private readonly IDrinkRepository drinkRepository;

        //uso uma DI para acessar o BD e conseguir as bebidas que tem
        public BebidaController(IDrinkRepository _drinkRepository)
        {
            this.drinkRepository = _drinkRepository;
        }

        public IActionResult Drinks(string brand)
        {
           IEnumerable<Drink> Drinks;
           

            if (string.IsNullOrEmpty(brand))
            {
                ViewData["Brand"] = "Todas as Marcas";
                Drinks = drinkRepository.Drinks;
            }
            else
            {
                ViewData["Brand"] = brand;
                Drinks = drinkRepository.Drinks.Where(p => p.Brand.Name.Equals(brand));

            }
            


            return View(Drinks);
        }

        /*
         * A ideia é fazer com que o programa entenda em que categoria eu estou querendo entrar. 
         * A ideia por tras dessa action é que, ao clicar em uma categoria desejada, o programa consiga capturar o nome da
         * categoria e filtrar ela baseada nas categorias que as bebidas possuem. Ex: clico em cerveja, entao nao mostrara nada
         * alem das cervejas registradas no BD.
         *  
         */
        public IActionResult Categories(string category)
        {

            //Crio uma lista IEnumerable de Drink
            IEnumerable<Drink> drinks;

            //Confiro se a category passada atraves do navegador é vazia. Se sim, ele mostrara todas as bebidas do site
            if (string.IsNullOrEmpty(category))
            {
                ViewData["Catagory"] = "Todas as Bebidas";
                drinks = drinkRepository.Drinks;
            }
            /*Caso nao, ele irá filtrar. A view Ddata receberá o nome da categoria para sabermos que categoria estamos vendo.
            * Depois, utilizo o LINQ, que basicamente é o mesmo que uma expressao lambda em Java, para filtrar todas as bebidas
            * que tem a mesma categoria passada. 
            */
            else
            {
                ViewData["Category"] = category;
                drinks = drinkRepository.Drinks.Where(p => p.Category.Name.Equals(category));
            }

            var drinkVM = new DrinkViewModel
            {
                Drinks=drinks,
                Category=category
            };
            

            return View(drinkVM);

        }

    }
}
