using proyecto.Alertas;
using proyecto.NotificacionesDto;
using proyecto.noticias;
using proyecto.EntityFrameworkCore;
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
using proyecto.Usuarios;
using proyecto.Alertas1;

namespace proyecto.Notificaciones
{
    public class NotificacionesAppService_Test : proyectoApplicationTestBase
    {
        private readonly INotificacionesAppService _notificacionesAppService;
        private readonly IDbContextProvider<proyectoDbContext> _dbContextProvider;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public NotificacionesAppService_Test()
        {
            _notificacionesAppService = GetRequiredService<INotificacionesAppService>();
            _dbContextProvider = GetRequiredService<IDbContextProvider<proyectoDbContext>>();
            _unitOfWorkManager = GetRequiredService<IUnitOfWorkManager>();
        }

        [Fact]
        public async Task Should_Get_Notificacion_For_User()
        {
            using (var unitOfWork = _unitOfWorkManager.Begin())
            {
                // Arrange
                var context = await _dbContextProvider.GetDbContextAsync();

                var user1 = new Usuario
                {
                    nombre = "juan",
                    apellido = "fernandez",
                    mail = "juan@gmail.com",
                    Notificaciones = new List<Notificacion>()
                };

                context.Usuarios.Add(user1);
                await context.SaveChangesAsync();
               

                context.Notificaciones.Add(new Notificacion
                {
                    AlertaId = 1,
                    descripcion = "Alerta 1",
                    fecha = DateTime.Now,
                    UsuarioId = 1, 
                    link = "http://ejemplo.com/1"
                });

                await context.SaveChangesAsync();
                await unitOfWork.CompleteAsync();

            }

            // Act
            var result = await _notificacionesAppService.GetNotificacionUserAsync("juan");

            // Assert
            Assert.Single(result);
            Assert.Equal(1, result[0].AlertaId); // Asegúrate de usar las propiedades correctas
            Assert.Equal("Alerta 1", result[0].descripcion);
        }

        public async Task Should_PersistirNotificaciones()
        {
            //Act

            var result = await _notificacionesAppService.PersistirNotificaciones(1, 1);

            //Assert

            Assert.Equal(result[0].descripcion, );

        }
    }
}

