using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace proyecto.Temas
{
    public class Tema: Entity<int>
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}
