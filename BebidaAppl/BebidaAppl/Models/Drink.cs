using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BebidaAppl.Models
{
    public class Drink
    {
        [Key]
        public int BebidaId { get; set; }

        [Required(ErrorMessage ="O campo nome é obrigatório")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O {0} Deve ter no mínimo {1} e no máximo {2}")]
        [Display(Name = "Nome da Bebida")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "O preço deve estar entre 1 e 999,99")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "O campo Descrição é obrigatório")]
        [MaxLength(50, ErrorMessage = "O {0} Deve ter no máximo {1}")]
        [Display(Name = "Descrição da bebida")]
        public string Description { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsBebidaPrefer { get; set; }

        
        [Display(Name = "Caminho Imagem Normal")]
        public string ImageUrl { get; set; }

        
        [Display(Name = "Caminho Imagem Miniatura")]
        public string ImageThumbnailUrl { get; set; }

        [Display(Name="Preferido?")]
        public bool InStock { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
