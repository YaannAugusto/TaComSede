using System.ComponentModel.DataAnnotations;

namespace BebidaAppl.Models
{
    public class Brand
    {
        public int BrandId { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O {0} Deve ter no mínimo {1} e no máximo {2}")]
        [Display(Name = "Nome da Marca")]
        public string Name { get; set; }

        [Display(Name = "Preferido?")]
        public bool isBrandPrefer { get; set; }
        public string ImageUrl { get; set; }
        public List<Drink> Drinks { get; set; }

    }
}
