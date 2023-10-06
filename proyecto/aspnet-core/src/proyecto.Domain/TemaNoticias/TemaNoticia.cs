using proyecto.noticias;
using proyecto.Temas;
using Volo.Abp.Domain.Entities;

namespace proyecto.TemaNoticias;

public class TemaNoticia : Entity<int>
{
    public int NoticiaId { get; set; }
    public Noticia Noticia { get; set; }
    public int TemaId { get; set; }
    public Tema Tema { get; set; }

}