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
        public IList<ListaNoticiaItem> ListaNoticiaItem { get; set; }
        
        public int TemaId { get; set; }
        public Tema Tema { get; set; }
        
        public IList<Noticia> ListaNoticia { get; set; }
        
        public int NoticiaId { get; set; }
        public Noticia Noticia1 { get; set; }

    }
}
