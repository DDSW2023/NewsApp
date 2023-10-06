using System;
using proyecto.Alertas;
using proyecto.Usuarios;
using Volo.Abp.Domain.Entities;

namespace proyecto.Notificaciones
{
    public class Notificacion : Entity<int>
    {
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        public string link { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int AlertaId { get; set; }
        public Alerta Alerta { get; set; }
    }
}