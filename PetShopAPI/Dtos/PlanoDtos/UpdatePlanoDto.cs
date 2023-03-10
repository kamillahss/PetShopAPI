using System.ComponentModel.DataAnnotations;

namespace PetShopAPI.Dtos.PlanoDtos
{
    public class UpdatePlanoDto
    {
        [Required]
        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public bool Disponivel { get; set; }
    }
}
