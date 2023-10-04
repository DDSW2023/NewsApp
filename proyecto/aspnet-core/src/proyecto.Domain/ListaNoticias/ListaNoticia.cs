using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using proyecto.Alertas;
using proyecto.ListaNoticiaItems;
using proyecto.noticias;
using proyecto.Notificaciones;
using Volo.Abp.Domain.Entities;

namespace proyecto.ListaNoticias
{
    public class ListaNoticia : Entity<int>
    {
        public String nombreLista { get; set; }
        public IList<ListaNoticiaItem> ListaNoticiaItem { get; set; }
        public ICollection<Alerta> Alertas { get; set; }
    }
}