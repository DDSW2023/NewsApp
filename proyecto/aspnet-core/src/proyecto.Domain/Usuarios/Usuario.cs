﻿using proyecto.Accesos;
using proyecto.Busquedas;
using proyecto.ListaNoticiaItems;
using proyecto.Notificaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace proyecto.Usuarios
{
    public class Usuario : Entity<int>
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public ICollection<Acceso> Accesos { get; set; }
        public ICollection<Busqueda> Busquedas { get; set; }
        public ICollection<Notificacion> Notificaciones { get; set; }
    }
}
