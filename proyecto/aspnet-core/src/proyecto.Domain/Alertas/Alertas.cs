using System;
using Volo.Abp.Domain.Entities;

namespace proyecto.Alertas;

public class Alerta : Entity<int>
{
    public DateTime fecha { get; set; }
    public String descripcion { get; set; }
}

