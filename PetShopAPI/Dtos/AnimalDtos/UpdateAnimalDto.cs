using PetShopAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace PetShopAPI.Dtos
{
    public class UpdateAnimalDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [StringLength(30, ErrorMessage = "O nome deve ter no máximo 30 caracteres")]
        public string Nome { get; set; }

        [Range(1, 25, ErrorMessage = "O campo peso deve ter entre 1 e 25.")]
        public decimal? Peso { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }

        [Required]
        public bool Castrado { get; set; }

        [Required, Range(0, 5)]
        public Especie Especie { get; set; }
    }
}
