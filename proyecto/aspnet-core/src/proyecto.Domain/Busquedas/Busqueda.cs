using proyecto.ListaNoticiaItems;
using proyecto.Usuarios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace proyecto.Busquedas
{
    public class Busqueda : Entity<int>
    {
        public string parametro { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
