using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using proyecto.Usuarios;
using proyecto.Errores;
using Volo.Abp.Domain.Entities;

namespace proyecto.Accesos;

public class Acceso : Entity<int>
{
    public DateTime fecha { get; set; }
    public float tiempoConsulta { get; set; }
        public ICollection<Error> Errores { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
