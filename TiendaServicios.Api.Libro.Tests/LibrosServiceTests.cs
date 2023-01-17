using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using TiendaServicios.Api.Libro.Aplicacion;
using TiendaServicios.Api.Libro.Dtos;
using TiendaServicios.Api.Libro.Modelo;
using TiendaServicios.Api.Libro.Persistencia;

namespace TiendaServicios.Api.Libro.Tests
{
    public class LibrosServiceTests
    {
        private IEnumerable<LibroMaterial> ObtenerDataPrueba()
        {
            A.Configure<LibroDto>().Fill(x => x.Titulo).AsArticleTitle().Fill(x => x.LibroId, () => { return Guid.NewGuid(); });
            var lista = A.ListOf<LibroMaterial>(30);
            lista[0].LibroId = Guid.Empty;
            return lista;
        }

        private Mock<ContextoLibro> CrearContexto()
        {
            var dataPrueba = ObtenerDataPrueba().AsQueryable();
            var dbSet = new Mock<DbSet<LibroMaterial>>();
            dbSet.As<IQueryable<LibroMaterial>>().Setup(x => x.Provider).Returns(dataPrueba.Provider);
            dbSet.As<IQueryable<LibroMaterial>>().Setup(x => x.Expression).Returns(dataPrueba.Expression);
            dbSet.As<IQueryable<LibroMaterial>>().Setup(x => x.ElementType).Returns(dataPrueba.ElementType);
            dbSet.As<IQueryable<LibroMaterial>>().Setup(x => x.GetEnumerator()).Returns(dataPrueba.GetEnumerator());

            dbSet.As<IAsyncEnumerable<LibroMaterial>>().Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new AsyncEnumerator<LibroMaterial>(dataPrueba.GetEnumerator()));

            dbSet.As<IQueryable<LibroMaterial>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<LibroMaterial>(dataPrueba.Provider));

            var contexto = new Mock<ContextoLibro>();
            contexto.Setup(x => x.Libros).Returns(dbSet.Object);
            return contexto;
        }

        [Fact]
        public async void GetLibros()
        {
            var mockContexto = CrearContexto();
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            var mapper = mapConfig.CreateMapper();

            var handler = new GetBooks.QueryHandler(mockContexto.Object, mapper);
            var query = new GetBooks.Query();
            var lista = await handler.Handle(query, new CancellationToken());

            Assert.True(lista.Any());
        }
    }
}