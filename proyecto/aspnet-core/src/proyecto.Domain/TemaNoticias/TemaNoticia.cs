using proyecto.noticias;
using proyecto.Temas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace proyecto.TemaNoticias
{
    public class TemaNoticia : Entity<int>
    {
        public int NoticiaId { get; set; }
        public Noticia Noticia { get; set; }
        public int TemaId { get; set; }
        public Tema Tema { get; set; }

    }
}
