using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto.ListaNoticiaItems;
using proyecto.ListaNoticias;
using proyecto.TemaNoticias;
using proyecto.Temas;
using Volo.Abp.Domain.Entities;

namespace proyecto.noticias
{
    public class Noticia: Entity<int>
    {
        public DateTime fecha { get; set; }
        public string titulo { get; set; }
        public string autor { get; set; }
        
        public string descripcion { get; set; }
        
        public string url { get; set; }
        
        public string urlImagen { get; set; }
        
        public string Contenido { get; set; }

        public IList<ListaNoticiaItem> ListaNoticiaItem { get; set; }
        
        public int TemaId { get; set; }
        public Tema Tema { get; set; }
        


    }
}
