using AutoMapper;
using TiendaServicios.Api.Libro.Dtos;
using TiendaServicios.Api.Libro.Modelo;

namespace TiendaServicios.Api.Libro.Tests
{
    internal class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<LibroMaterial, LibroDto>().ReverseMap();
        }
    }
}
