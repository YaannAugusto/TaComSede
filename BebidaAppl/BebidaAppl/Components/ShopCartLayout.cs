using BebidaAppl.Models;
using BebidaAppl.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BebidaAppl.ViewComponents
{
    /*
     * Uma ViewComponent é bem parecido com uma partial view, a diferença que ele é mais poderoso.
     * A aplicação dele serve para coisas mais complexas do que uma partial view, como no caso um carrinho de compra.
     * 
     */
    public class ShopCartLayout : ViewComponent
    {

        private readonly ShopCart _cart;

        public ShopCartLayout(ShopCart cart)
        {
            _cart = cart;
        }
        public IViewComponentResult Invoke()
        {

            //var itens = _cart.GetShopCartItems();

            var itens = new List<ShopCartItem>()
            {
                new ShopCartItem()
            };

            
            _cart.ShopCartItems = itens;

            var viewModel = new ShopCartViewModel
            {
                ShopCart = _cart,
                Total = _cart.TotalCartItem()
            };

            return View(viewModel);
        }
    }
}


