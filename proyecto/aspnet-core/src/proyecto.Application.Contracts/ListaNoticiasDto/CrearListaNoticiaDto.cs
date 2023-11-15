using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace proyecto.ListaNoticiasDto
{
    public class CrearListaNoticiaDto : EntityDto<int>
    {
        public String nombreLista { get; set; }
    }
}
