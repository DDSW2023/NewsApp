using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace proyecto.Temas;

public class CrearTemaDto : EntityDto<int>
{
    
    [Required]
    public string nombre { get; set; }
    
    [Required]
    public string descripcion { get; set; }
    
}