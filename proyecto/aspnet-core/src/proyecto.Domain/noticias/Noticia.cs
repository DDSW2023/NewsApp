using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto.ListaNoticiaItems;
using proyecto.ListaNoticias;
using proyecto.TemaNoticias;
using Volo.Abp.Domain.Entities;

namespace proyecto.noticias
{
    public class Noticia: Entity<int>
    {
        public DateTime fecha { get; set; }
        public string titulo { get; set; }
        public string autor { get; set; }
        public IList<ListaNoticiaItem> ListaNoticiaItem { get; set; }
        
        public IList<TemaNoticia> TemaNoticias { get; set; }
    }
}
