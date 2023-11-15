using proyecto.Accesos;
using Volo.Abp.Domain.Entities;

namespace proyecto.Errores;

public class Error : Entity<int>
{
    public string descripcion { get; set; }
    public int AccesoId { get; set; }
    public Acceso Acceso { get; set; }
}