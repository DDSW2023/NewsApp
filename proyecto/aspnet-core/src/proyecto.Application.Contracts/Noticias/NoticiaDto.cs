using System;
using System.Collections.Generic;
using proyecto.ListaNoticiaItemsDto;
using proyecto.TemaNoticiasDto;
using Volo.Abp.Application.Dtos;

namespace proyecto.Noticias;

public class NoticiaDto : EntityDto<int>
{
    public string? FechaPublicado { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
        
    public string Descripcion { get; set; }
        
    public string Url { get; set; }
        
    public string UrlDeImagen { get; set; }
        
    public string Contenido { get; set; }
        
    public string? tema { get; set; }

    
}