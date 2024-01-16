using System;
using System.Collections.Generic;
using System.Text;
using proyecto.AlertasDto;
using proyecto.ListaNoticiaItemsDto;
using proyecto.Noticias;
using Volo.Abp.Application.Dtos;

namespace proyecto.ListaNoticiasDto
{
    public class ListaNoticiaDto : EntityDto <int>
    {
        public String nombreLista { get; set; }
        public ICollection<ListaNoticiaDto> ListaNoticias { get; set; }
        public ICollection<NoticiaDto> ListaNoticiasItems { get; set; }
        public ICollection<AlertaDto> Alertas { get; set; }
    }
}
