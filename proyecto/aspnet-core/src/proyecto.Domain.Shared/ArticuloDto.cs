using System;

namespace proyecto.noticias
{
    public class ArticuloDto
    {
        public string Autor { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public string Url { get; set; }

        public string UrlDeImagen { get; set; }

        public DateTime? FechaPublicado { get; set; }

        public string Contenido { get; set; }
    }
}