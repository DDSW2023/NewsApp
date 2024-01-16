using System;

namespace proyecto.Notificaciones;

public class NotificacionesResponseDto
{
    public DateTime fecha { get; set; }
    public string descripcion { get; set; }
    public string link { get; set; }
    public int UsuarioId { get; set; }
    public int AlertaId { get; set; }
}