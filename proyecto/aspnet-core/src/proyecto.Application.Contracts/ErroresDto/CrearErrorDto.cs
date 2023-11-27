using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace proyecto.ErroresDto;

public class CrearErrorDto : EntityDto<int>
{
    [Required]
    public string descripcion { get; set; }

    [Required]
    public int AccesoId { get; set; }

}