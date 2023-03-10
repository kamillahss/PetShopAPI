using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopAPI.Models
{
    [Table("Tbl_Consulta")]
    public class Consulta
    {
        public int VeterinarioId { get; set; }

        public int AnimalId { get; set; }

        public Veterinario Veterinario { get; set; }

        public Animal Animal { get; set; }

        public DateTime DataHora { get; set; }
    }
}
