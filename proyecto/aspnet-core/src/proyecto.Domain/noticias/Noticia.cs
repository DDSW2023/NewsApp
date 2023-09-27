using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto.ListaNoticiaItems;
using proyecto.ListaNoticias;
using Volo.Abp.Domain.Entities;

namespace proyecto.noticias
{
    public class Noticia: Entity<int>
    {
        public DateTime fecha { get; set; }
        public string titulo { get; set; }
        public string autor { get; set; }
        public string encabezado { get; set; }
        public string cuerpo { get; set; }

        public IList<ListaNoticiaItem> ListaNoticiaItem { get; set; }
    }
}
