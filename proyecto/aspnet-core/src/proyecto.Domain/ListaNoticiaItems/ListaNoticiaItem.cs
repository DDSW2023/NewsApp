using proyecto.ListaNoticias;
using proyecto.noticias;
using Volo.Abp.Domain.Entities;

namespace proyecto.ListaNoticiaItems
{
    public class ListaNoticiaItem : Entity<int>
    {
        public int ListaNoticiaId { get; set; }
        public ListaNoticia ListaNoticia { get; set; }
    
        public int NoticiaId { get; set; }
        public Noticia Noticia { get; set; }
    }
}