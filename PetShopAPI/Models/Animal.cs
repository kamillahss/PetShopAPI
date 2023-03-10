using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopAPI.Models
{
    [Table("Tbl_Animal")]
    public class Animal
    {
        [Column("Id")]
        public int AnimalId { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [StringLength(30, ErrorMessage = "O nome deve ter no máximo 30 caracteres")]
        public string Nome { get; set; }

        [Range(1,25, ErrorMessage = "O campo peso deve ter entre 1 e 25.")]
        public decimal? Peso { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }

        [Required]
        public bool Castrado { get; set; }

        [Required, Range(0,5)]
        public Especie Especie { get; set; }

        public Plano Plano { get; set; }
        public int? PlanoId { get; set; }

        public ICollection<Consulta> Consultas { get; set; }
    }

    public enum Especie
    {
        Cachorro, Gato, Peixe, Rato, Coelho, Ave
    }
}
