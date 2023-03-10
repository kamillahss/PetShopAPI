using AutoMapper;
using PetShopAPI.Dtos;
using PetShopAPI.Models;

namespace PetShopAPI.Profiles
{
    public class AnimalProfile : Profile
    {
        public AnimalProfile()
        {
            CreateMap<CreateAnimalDto, Animal>();
            CreateMap<Animal, ReadAnimalDto>();
            CreateMap<UpdateAnimalDto, Animal>();

        }
    }
}
