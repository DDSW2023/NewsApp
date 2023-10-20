using System;
using System.Collections.Generic;
using proyecto.ListaNoticiaItemsDto;
using proyecto.TemaNoticiasDto;
using Volo.Abp.Application.Dtos;

namespace proyecto.Noticias;

public class NoticiaDto : EntityDto<int>
{
    public DateTime fecha { get; set; }
    public string titulo { get; set; }
    public string autor { get; set; }
    public IList<ListaNoticiaItemDto> ListaNoticiaItem { get; set; }
    public IList<TemaNoticiaDto> TemaNoticias { get; set; }
}