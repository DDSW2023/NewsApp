using System;
using System.Collections.Generic;
using System.Text;
using proyecto.AlertasDto;
using proyecto.ListaNoticiaItemsDto;
using Volo.Abp.Application.Dtos;

namespace proyecto.ListaNoticiasDto
{
    public class ListaNoticiaDto : EntityDto <int>
    {
        public String nombreLista { get; set; }
        public IList<ListaNoticiaItemDto> ListaNoticiaItem { get; set; }
        public ICollection<AlertaDto> Alertas { get; set; }
    }
}
