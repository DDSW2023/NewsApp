using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using proyecto.Alertas1;
using proyecto.noticias;
using proyecto.Notificaciones;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace proyecto.ListaNoticias
{
    public class ListaNoticia : Entity<int>
    {
        public String? nombreLista { get; set; }
        public ICollection<Noticia>? ListaNoticias { get; set; }
        public ICollection<Alerta>? Alertas { get; set; }
        
        public IdentityUser? User { get; set; }
        public ICollection<ListaNoticia>? Listas { get; set;}

        public ListaNoticia()
        {
            this.Listas = new List<ListaNoticia>();
        }
        
    }
}