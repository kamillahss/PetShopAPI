using PetShopAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace PetShopAPI.Dtos.VeterinarioDtos
{
    public class CreateVeterinarioDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [StringLength(80, MinimumLength = 6, ErrorMessage = "O nome deve ter no mínimo 6 caracteres e no máximo 80.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo especialidade é obrigatório.")]
        public string Especialidade { get; set; }

        public ContratoTrabalho ContratoTrabalho { get; set; }
    }
}
