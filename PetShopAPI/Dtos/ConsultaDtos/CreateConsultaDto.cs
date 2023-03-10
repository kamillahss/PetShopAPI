using PetShopAPI.Models;

namespace PetShopAPI.Dtos.ConsultaDtos
{
    public class CreateConsultaDto
    {
        public int VeterinarioId { get; set; }

        public int AnimalId { get; set; }

        public DateTime DataHora { get; set; }
    }
}
