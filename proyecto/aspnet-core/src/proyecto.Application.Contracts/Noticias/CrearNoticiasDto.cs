using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace proyecto.Noticias;

public class CrearNoticiasDto : EntityDto<int>
{
    [Required] public string? fecha { get; set; }
    [Required] public string? titulo { get; set; }
    [Required] public string? autor { get; set; }
    [Required] public string? descripcion { get; set; }
    [Required] public string? url { get; set; }
    [Required] public string? urlImagen { get; set; }
    [Required] public string? Contenido { get; set; }
    [Required] public string? tema { get; set; }
    [Required] public int? ListaNoticiasId { get; set; }

}