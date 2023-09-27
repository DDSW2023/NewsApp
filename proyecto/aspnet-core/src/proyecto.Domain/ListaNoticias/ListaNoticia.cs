using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using proyecto.ListaNoticiaItems;
using proyecto.noticias;
using Volo.Abp.Domain.Entities;

namespace proyecto.ListaNoticias
{
    public class ListaNoticia : Entity<int>
    {
        public String nombreLista { get; set; }

        public IList<ListaNoticiaItem> ListaNoticiaItem { get; set; }
    }
}