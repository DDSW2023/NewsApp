using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace proyecto.UsuariosDto;

public class CrearUsuarioDto : EntityDto<int>
{
    [Required]
    public string nombre { get; set; }

    [Required]
    public string apellido { get; set; }

    [Required]
    public string mail { get; set; }
}