using AutoMapper;
using UsuarioApi.Dtos;
using UsuarioApi.Models;

namespace UsuarioApi.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
