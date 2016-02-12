using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaBiblio.Models
{
    public class Auteurs
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public static List<Auteurs> listeDesAuteurs = new List<Auteurs>
        {
            new Auteurs {Id=1, Nom="Jules Verne"},
            new Auteurs {Id=2, Nom="Victor Hugo"},
            new Auteurs {Id=3, Nom="Albert Camus"}
        };

        public Auteurs()
        {/*
            listeDesAuteurs = new List<Auteurs>
            {
                new Auteurs {Id=1, Nom="Jules Verne"},
                new Auteurs {Id=2, Nom="Victor Hugo"},
                new Auteurs {Id=3, Nom="Albert Camus"}
            };
          */
        }
    }
}