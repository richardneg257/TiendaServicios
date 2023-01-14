using AutoMapper;
using TiendaServicios.Api.Libro.Dtos;
using TiendaServicios.Api.Libro.Modelo;

namespace TiendaServicios.Api.Libro.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LibroMaterial, LibroDto>().ReverseMap();
        }
    }
}
