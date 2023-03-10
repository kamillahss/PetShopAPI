using AutoMapper;
using PetShopAPI.Dtos.VeterinarioDtos;
using PetShopAPI.Models;

namespace PetShopAPI.Profiles
{
    public class VeterinarioProfile : Profile
    {
        public VeterinarioProfile()
        {
            CreateMap<CreateVeterinarioDto, Veterinario>();
            CreateMap<Veterinario, ReadVeterinarioDto>();
            CreateMap<UpdateVeterinarioDto, Veterinario>();
        }
    }
}
