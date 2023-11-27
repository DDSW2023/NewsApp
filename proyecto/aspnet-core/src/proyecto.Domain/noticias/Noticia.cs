using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto.ListaNoticias;
using Volo.Abp.Domain.Entities;

namespace proyecto.noticias
{
    public class Noticia: Entity<int>
    {
        public string? fecha { get; set; }
        public string? titulo { get; set; }
        public string? autor { get; set; }
        
        public string? descripcion { get; set; }
        
        public string? url { get; set; }
        
        public string? urlImagen { get; set; }
        
        public string? Contenido { get; set; }
        
        public string? tema { get; set; }


        public int? ListaNoticiasId { get; set; }
        public ListaNoticia? ListaNoticia { get; set; }
        
    }
}
