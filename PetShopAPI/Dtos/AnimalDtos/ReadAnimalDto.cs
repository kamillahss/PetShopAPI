using PetShopAPI.Models;

namespace PetShopAPI.Dtos
{
    public class ReadAnimalDto
    {
        public int AnimalId { get; set; }

        public string Nome { get; set; }

        public decimal? Peso { get; set; }

        public DateTime DataNascimento { get; set; }

        public bool Castrado { get; set; }

        public Especie Especie { get; set; }

        public Plano Plano { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}
