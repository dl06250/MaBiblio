using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaBiblio.Models
{
    public class Livre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public DateTime Parution { get; set; }
        public Auteur Auteur { get; set; }
    }
}