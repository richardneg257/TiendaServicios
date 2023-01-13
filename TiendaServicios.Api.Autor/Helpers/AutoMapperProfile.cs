using AutoMapper;
using TiendaServicios.Api.Autor.Dtos;
using TiendaServicios.Api.Autor.Modelo;

namespace TiendaServicios.Api.Autor.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AutorLibro, AutorDto>().ReverseMap();
        }
    }
}
