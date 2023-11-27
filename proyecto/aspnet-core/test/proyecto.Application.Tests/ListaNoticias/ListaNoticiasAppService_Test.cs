using proyecto.EntityFrameworkCore;
using proyecto.ListaNoticiasDto;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Uow;
using Xunit;

namespace proyecto.ListaNoticias
{
    public class ListaNoticiasAppService_Test : proyectoApplicationTestBase
    {
        private readonly IListaNoticiasAppService _listaNoticiasAppService;
        private readonly IDbContextProvider<proyectoDbContext> _dbContextProvider;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ListaNoticiasAppService_Test()
        {
            _listaNoticiasAppService = GetRequiredService<IListaNoticiasAppService>();
            _dbContextProvider = GetRequiredService<IDbContextProvider<proyectoDbContext>>();
            _unitOfWorkManager = GetRequiredService<IUnitOfWorkManager>();
        }

        [Fact]
        public async Task Should_Get_All_Themes()
        {
            //Act
            var listaNoticias = await _listaNoticiasAppService.GetThemesAsync();
            //Assert
            listaNoticias.ShouldNotBeNull();
            listaNoticias.Count.ShouldBeGreaterThan(1);
        }

        [Fact]
        public async Task Should_Create_ListaNoticias()
        {
            //Arrange            
            var input = new CrearListaNoticiaDto { nombreLista = "nueva lista noticias" };

            //Act
            var newListaNoticias = await _listaNoticiasAppService.CreateListaNoticiaAsync(input);

            //Assert
            // Se verifican los datos devueltos por el servicio
            newListaNoticias.ShouldNotBeNull();
            newListaNoticias.Id.ShouldBePositive();
            // se verifican los datos persistidos por el servicio
            using (var uow = _unitOfWorkManager.Begin())
            {
                var dbContext = await _dbContextProvider.GetDbContextAsync();
                dbContext.ListaNoticias.FirstOrDefault(t => t.Id == newListaNoticias.Id).ShouldNotBeNull();
                dbContext.ListaNoticias.FirstOrDefault(t => t.Id == newListaNoticias.Id).nombreLista.ShouldBe(input.nombreLista);
            }
        }

        [Fact]
        public async Task Should_Update_ListaNoticias()
        {
            //Arrange            
            var input = new CrearListaNoticiaDto { nombreLista = "nueva lista noticias", Id = 1 };

            //Act
            var newListaNoticias = await _listaNoticiasAppService.CreateListaNoticiaAsync(input);

            //Assert
            // Se verifican los datos devueltos por el servicio
            newListaNoticias.ShouldNotBeNull();
            newListaNoticias.Id.ShouldBePositive();
            // se verifican los datos persistidos por el servicio
            using (var uow = _unitOfWorkManager.Begin())
            {
                var dbContext = await _dbContextProvider.GetDbContextAsync();
                dbContext.ListaNoticias.FirstOrDefault(t => t.Id == newListaNoticias.Id).ShouldNotBeNull();
                dbContext.ListaNoticias.FirstOrDefault(t => t.Id == newListaNoticias.Id).nombreLista.ShouldBe(input.nombreLista);
            }
        }

        [Fact]
        public async Task Should_Create_Child_ListaNoticias()
        {
            //Arrange            
            var input = new CrearListaNoticiaDto { nombreLista = "nuevo ListaNoticias hija", ParentId = 1 };

            //Act
            var newListaNoticias = await _listaNoticiasAppService.CreateListaNoticiaAsync(input);

            //Assert
            // Se verifican los datos devueltos por el servicio
            newListaNoticias.ShouldNotBeNull();
            newListaNoticias.Id.ShouldBePositive();
            // se verifican los datos persistidos por el servicio
            using (var uow = _unitOfWorkManager.Begin())
            {
                var dbContext = await _dbContextProvider.GetDbContextAsync();
                dbContext.ListaNoticias.FirstOrDefault(t => t.Id == newListaNoticias.Id).ShouldNotBeNull();
                dbContext.ListaNoticias.FirstOrDefault(t => t.Id == newListaNoticias.Id).nombreLista.ShouldBe(input.nombreLista);
            }
        }



    }
}
