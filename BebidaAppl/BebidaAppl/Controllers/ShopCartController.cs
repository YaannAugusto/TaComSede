using BebidaAppl.Models;
using BebidaAppl.Repositories;
using BebidaAppl.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BebidaAppl.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IDrinkRepository _drinkRepository;
        private readonly ShopCart _cart;


        public ShopCartController(IDrinkRepository drinkRepository, ShopCart cart)
        {
            _drinkRepository = drinkRepository;
            _cart = cart;
        }

        public IActionResult Index()
        {
            var itens = _cart.GetShopCartItems();
            _cart.ShopCartItems = itens;

            var viewModel = new ShopCartViewModel
            {
                ShopCart = _cart,
                Total = _cart.TotalCartItem()
            };

            return View(viewModel);
        }

        public IActionResult AddToCart(int id)
        {
            var cId = _drinkRepository.Drinks.FirstOrDefault(p => p.BebidaId == id);

            if(cId != null)
            {
                _cart.AddCartItem(cId);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveToCart(int id)
        {
            var cId = _drinkRepository.Drinks.FirstOrDefault(p => p.BebidaId == id);

            if ( cId != null)
            {
                _cart.RemoveCartItem(cId);
            }
            return RedirectToAction("Index");

        }
    }
}
