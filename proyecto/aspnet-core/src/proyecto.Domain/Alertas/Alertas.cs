using System;
using System.Collections.Generic;
using proyecto.ListaNoticias;
using proyecto.Notificaciones;
using Volo.Abp.Domain.Entities;

namespace proyecto.Alertas;

public class Alerta : Entity<int>
{
    public DateTime fecha { get; set; }
    public String descripcion { get; set; }
    public ICollection<Notificacion> Notificaciones { get; set; }
    public int? ListaNoticiaId { get; set; }
    public ListaNoticia? ListaNoticia { get; set; }
}

