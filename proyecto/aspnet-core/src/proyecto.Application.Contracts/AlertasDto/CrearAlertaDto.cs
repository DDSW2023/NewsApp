using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace proyecto.AlertasDto
{
    public class CrearAlertaDto:EntityDto<int>
    {
        [Required]
        public DateTime fecha { get; set; }
        [Required]
        public String descripcion { get; set; }
        [Required]
        public int ListaNoticiaId { get; set; }
    }
}
