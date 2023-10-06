using proyecto.Usuarios;
using Volo.Abp.Domain.Entities;

namespace proyecto.Busquedas;

public class Busqueda : Entity<int>
{
    public string parametro { get; set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
}