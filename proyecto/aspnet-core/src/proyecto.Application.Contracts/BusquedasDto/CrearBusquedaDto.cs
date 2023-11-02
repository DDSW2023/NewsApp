using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace proyecto.BusquedasDto;

public class CrearBusquedaDto : EntityDto<int>
{
    [Required]
    public string parametro { get; set; }

    [Required]
    public int UsuarioId { get; set; }

}