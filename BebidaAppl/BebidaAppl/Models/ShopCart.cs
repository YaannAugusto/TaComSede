using System.ComponentModel.DataAnnotations;
using BebidaAppl.Context;
using Microsoft.EntityFrameworkCore;

namespace BebidaAppl.Models
{
    /*
     * 
     * Nesta classe, ela representa o Carrinho como um todo, tendo uma lista de todos itens do carrinho (clss: ShopCartITem);
     * 
     */
    public class ShopCart
    {
        private readonly AppDbContext _context;
        /*
         * 
         * Faço uma injeção de dependencia context para poder acessar o banco de dados;
         * 
         */
        public ShopCart(AppDbContext context)
        {
            _context = context;
        }

        public string ScId { get; set; }
        public List<ShopCartItem> ShopCartItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            //crio uma sessão
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //crio um serviço no contexto que fiz para a DI;
            var context = services.GetService<AppDbContext>();

            //Pega uma string "CartId" ou cria um Guid para string;
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            //Seta o Id anterior
            session.SetString("CartId", cartId);

            //coloca o Id no cart Id
            return new ShopCart(context)
            {
                ScId = cartId
            }; 
        }

        public void AddCartItem(Drink drink)
        {

            /*
             * 
             * Acesso A tabela de ShoCartItems e retorno um item único que possui a mesma Id drink com a Id no banco e a mesma Id de ShopCart;
             * 
             */
            var scItem = _context.ShopCartItems
                .SingleOrDefault(p => p.Drink.BebidaId == drink.BebidaId && p.ScId == ScId);

            /*
             *  Verifico se é null scItem, baseado linQ anterior;
             *  Se for null, significa que não existe um Item ainda, então ele é criado com a Id, o drink selecionado e uma contagem de um item e add no BD;
             *  Caso exista, ele faz um incremento de amount , assim não se repete item;
             */
            if(scItem == null)
            {
                var item = new ShopCartItem
                {
                    ScId = ScId,
                    Drink = drink,
                    Amount = 1
                };
                _context.ShopCartItems.Add(scItem);
            }
            else
            {
                scItem.Amount++;
            }

            _context.SaveChanges();
        }

        public void RemoveCartItem(Drink drink)
        {
            /*
             * Acesso A tabela de ShoCartItems e retorno um item único que possui a mesma Id drink com a Id no banco e a mesma Id de ShopCart;
             */
            var scItem = _context.ShopCartItems.SingleOrDefault(p => p.Drink.BebidaId == drink.BebidaId && p.ScId == ScId);
            
            /*
             * Primeiro de tudo, vejo se o scItem é diferente de null, ou seja, se existe;
             * Caso exista e o item ter um amount maior que um, ele diminuirá;
             * Caso seja menor que 1, ele exclui direto do carrinho;
             */
            if(scItem != null)
            {
                if(scItem.Amount > 1)
                {
                    scItem.Amount--;
                    
                }
                else
                {
                    _context.ShopCartItems.Remove(scItem);
                }
            }

            _context.SaveChanges();
            
        }

        /*
         * 
         * Aqui é bem mais simples, Ele retorna todos os items onde o Id do ShopCart seja igual, incluindo o Drink e retorna tudo em uma lista;
         * 
         */
        public List<ShopCartItem> GetShopCartItems()
        {
            return ShopCartItems ?? 
                  (ShopCartItems = _context.ShopCartItems
                                         .Where(p => p.ScId == ScId)
                                         .Include(d => d.Drink)
                                         .ToList()) ;
        }
        

        /*
         * Acesso o BD e trago a Id Do ShopCart que desejo;
         * Depois faço um RemoveRange, que basicamente exclui todos os itens que tem esse Id, tirando do carrinho e deixando-a vazia;
         */
        public void DeleteShopCart()
        {
            var sc = _context.ShopCartItems.Where(prop => prop.ScId == ScId);

            _context.ShopCartItems.RemoveRange(sc);
            _context.SaveChanges();
        }

        /*
         *  Acesso o BD e trago a Id Do ShopCart que desejo;
         *  Seleciono A quantidade de cada item e multiplico Pelo preço do Drink;
         *  Depois, uso a função Sum(), que soma todas as contas feitas;
         */
        public decimal TotalCartItem()
        {
            var total = _context.ShopCartItems.Where(p => p.ScId == ScId).Select(p => p.Amount * p.Drink.Price).Sum();

            return total;
        }
    }
}
