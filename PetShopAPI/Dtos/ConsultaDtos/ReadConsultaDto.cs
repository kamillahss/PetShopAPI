using PetShopAPI.Models;

namespace PetShopAPI.Dtos.ConsultaDtos
{
    public class ReadConsultaDto
    {
        public int VeterinarioId { get; set; }

        public int AnimalId { get; set; }

        public Veterinario Veterinario { get; set; }

        public Animal Animal { get; set; }

        public DateTime DataHora { get; set; }
    }
}
