using System.ComponentModel.DataAnnotations;

namespace BebidaAppl.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }


        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O {0} Deve ter no mínimo {1} e no máximo {2}")]
        [Display(Name = "Nome da Categoria")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório")]
        [MaxLength(50, ErrorMessage = "O {0} Deve ter no máximo {1}")]
        [Display(Name = "Descrição da Categoria")]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public List<Drink> Drinks { get; set; }
    }
}
