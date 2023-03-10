using AutoMapper;
using PetShopAPI.Dtos.PlanoDtos;
using PetShopAPI.Models;

namespace PetShopAPI.Profiles
{
    public class PlanoProfile : Profile
    {
        public PlanoProfile()
        {
            CreateMap<CreatePlanoDto, Plano>();
            CreateMap<Plano, ReadPlanoDto>();
            CreateMap<UpdatePlanoDto, Plano>();
        }
    }
}
