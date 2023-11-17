using System.ComponentModel.DataAnnotations;

namespace BebidaAppl.Models
{
    /*
     * 
     * 
     * A Criação dessa classe serve para Identificar um item dendto de um carrinho de compra 
     * Criado.
     * 
     * 
     */

    public class ShopCartItem
    {
        [Key]
        public int CartItemId { get; set; }
        public int Amount { get; set; }

        /*
         * Este no caso é especial. Eu identifico um carrinho de compra de que eu quiser. Por exemplo, um carrinho com um Id de 1 tem 
         * Os item coca e uma cerveja; no 2, ele possui um Um vinho e uma água; e assim indo;
         */
        [StringLength(300)]
        public string ScId { get; set; }
        public Drink Drink { get; set; }
    }
}
