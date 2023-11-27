using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace proyecto.ListaNoticiasDto
{
    public class CrearListaNoticiaDto : EntityDto<int>
    {
        [Required]
        public String nombreLista { get; set; }
        
        public int? Id { get; set; }

        public int? ParentId { get; set; }
    }
}
