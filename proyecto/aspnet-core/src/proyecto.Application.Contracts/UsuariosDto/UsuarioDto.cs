using System.Collections.Generic;
using proyecto.AccesosDto;
using proyecto.BusquedasDto;
using proyecto.NotificacionesDto;
using Volo.Abp.Application.Dtos;

namespace proyecto.UsuariosDto;
public class UsuarioDto : EntityDto<int>
{
    public string nombre { get; set; }
    public string apellido { get; set; }
    public string mail { get; set; }
    public IList<AccesoDto> Accesos { get; set; }
    public IList<BusquedaDto> Busquedas { get; set; }
    public IList<NotificacionDto> Notificaciones { get; set; }
}
