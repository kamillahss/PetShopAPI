using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopAPI.Models
{
    [Table("Tbl_Veterinario")]
    public class Veterinario
    {
        [Column("Id")]
        public int VeterinarioId { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório."), MaxLength(80)]
        [StringLength(80, MinimumLength = 6, ErrorMessage = "O nome deve ter no mínimo 6 caracteres e no máximo 80.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo especialidade é obrigatório.")]
        public string Especialidade { get; set; }


        public ContratoTrabalho ContratoTrabalho { get; set; }
        public int ContratoTrabalhoId { get; set; }

        public ICollection<Consulta> Consultas { get; set; }
    }
}
