
using proyecto.Alertas;
using proyecto.noticias;
using proyecto.EntityFrameworkCore;
using proyecto.AlertasDto;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Uow;
using Xunit;


namespace proyecto.Alertas
{
    public class AlertasAppService_Test : proyectoApplicationTestBase
    {
        private readonly IAlertasAppService _alertasAppService;
        private readonly IDbContextProvider<proyectoDbContext> _dbContextProvider;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public AlertasAppService_Test()
        {
            _alertasAppService = GetRequiredService<IAlertasAppService>();
            _dbContextProvider = GetRequiredService<IDbContextProvider<proyectoDbContext>>();
            _unitOfWorkManager = GetRequiredService<IUnitOfWorkManager>();
        }

        [Fact]
        public async Task Should_Create_Alerts_For_New_News()
        {
            //Arrange
            var crearAlertaDto = new CrearAlertaDto();
            var textoBusqueda = "texto de prueba";
            //Act
            var result = await _alertasAppService.CreateAlertaAsync(crearAlertaDto, textoBusqueda, 1); // si no se tiene un usuario con id 1, no anda, se debe crear
            //Assert
            Assert.NotNull(result);
            Assert.Equal(textoBusqueda, result.descripcion);

        }


    }
}
