using proyecto.Errores;
using proyecto.ListaNoticiaItems;
using proyecto.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace proyecto.Accesos
{
    public class Acceso : Entity<int>
    {
        public DateTime fecha { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaFin { get; set; }
        public ICollection<Error> Errores { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
