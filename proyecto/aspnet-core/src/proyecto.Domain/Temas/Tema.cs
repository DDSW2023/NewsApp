using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto.TemaNoticias;
using Volo.Abp.Domain.Entities;
using proyecto.TemaNoticias;

namespace proyecto.Temas
{
    public class Tema: Entity<int>
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public IList<TemaNoticia> TemaNoticias { get; set; }
    }
}
