using PetShopAPI.Models;

namespace PetShopAPI.Dtos.VeterinarioDtos
{
    public class ReadVeterinarioDto
    {
        public int VeterinarioId { get; set; }

        public string Nome { get; set; }

        public string Especialidade { get; set; }

        public ContratoTrabalho ContratoTrabalho { get; set; }
        public int ContratoTrabalhoId { get; set; }
    }
}
