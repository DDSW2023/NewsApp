using proyecto.Accesos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace proyecto.Errores
{
    public class Error : Entity<int>
    {
        public string descripcion { get; set; }
        public int AccesoId { get; set; }
        public Acceso Acceso { get; set; }
    }
}
