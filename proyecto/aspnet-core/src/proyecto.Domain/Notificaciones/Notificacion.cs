using System;
using Volo.Abp.Domain.Entities;

namespace proyecto.Notificaciones
{
    public class Notificacion : Entity<int>
    {
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        public string link { get; set; }
    }
}