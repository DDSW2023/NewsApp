using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto.noticias
{
    /// <summary>
    /// Este dto representa la respuesta de la api de noticias. Lo pongo en este proyecto ya que son diferentes a los dtos de application
    /// </summary>
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