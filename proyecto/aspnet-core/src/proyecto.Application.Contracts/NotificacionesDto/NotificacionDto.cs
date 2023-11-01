using System;
using Volo.Abp.Application.Dtos;

namespace proyecto.NotificacionesDto;
public class NotificacionDto : EntityDto<int>
{
    public DateTime fecha { get; set; }
    public string descripcion { get; set; }
    public string link { get; set; }

    /*
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    public int AlertaId { get; set; }
    public Alerta Alerta { get; set; }
    */
}
