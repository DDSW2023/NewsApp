using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace proyecto.Secciones
{
    public class Seccion: Entity<int>
    {
        public string titulo { get; set; } 
        public int cuerpo { get; set; }
    }
}
