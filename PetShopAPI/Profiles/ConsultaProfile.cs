using AutoMapper;
using PetShopAPI.Dtos.ConsultaDtos;
using PetShopAPI.Models;

namespace PetShopAPI.Profiles
{
    public class ConsultaProfile : Profile
    {
        public ConsultaProfile()
        {
            CreateMap<CreateConsultaDto, Consulta>();
            CreateMap<Consulta, ReadConsultaDto>();
        }
    }
}
