using proyecto.ListaNoticiaItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace proyecto.Busquedas
{
    public class Busqueda : Entity<int>
    {
        public string parametro { get; set; }
    }
}
