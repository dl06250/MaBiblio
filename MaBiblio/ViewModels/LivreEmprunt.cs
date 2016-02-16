using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MaBiblio.Models;

namespace MaBiblio.ViewModels
{
    public class LivreEmprunt
    {
        public Livre Livre { get; set; }
        public Client Emprunteur { get; set; }
    }
}