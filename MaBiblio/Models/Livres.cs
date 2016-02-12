using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaBiblio.Models
{
    public class Livres
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public DateTime Parution { get; set; }
        public Auteurs Auteur { get; set; }

        public static List<Livres> listeDesLivres = new List<Livres>
        {
            new Livres {Id=1, Auteur=Auteurs.listeDesAuteurs.Find(a => a.Id==1), Parution=new DateTime(1865,1,1), Titre="De la terre à la lune"},
            new Livres {Id=2, Auteur=Auteurs.listeDesAuteurs.Find(a => a.Id==1), Parution=new DateTime(1864,1,1), Titre="Voyage au centre de la terre"},
            new Livres {Id=3, Auteur=Auteurs.listeDesAuteurs.Find(a=> a.Id==2), Parution=new DateTime(1862,1,1), Titre="Les misérables"},
            new Livres {Id=4, Auteur=Auteurs.listeDesAuteurs.Find(a=> a.Id==3), Parution=new DateTime(1942,1,1), Titre="L'étranger"},
            new Livres {Id=5, Auteur=Auteurs.listeDesAuteurs.Find(a=> a.Id==3), Parution=new DateTime(1947,1,1), Titre="La peste"}
        };

        public Livres()
        {/*
            listeDesLivres = new List<Livres>
            {
                new Livres {Id=1, Auteur=Auteurs.listeDesAuteurs.Find(a => a.Id==1), Parution=new DateTime(1865,1,1), Titre="De la terre à la lune"},
                new Livres {Id=2, Auteur=Auteurs.listeDesAuteurs.Find(a => a.Id==1), Parution=new DateTime(1864,1,1), Titre="Voyage au centre de la terre"},
                new Livres {Id=3, Auteur=Auteurs.listeDesAuteurs.Find(a=> a.Id==2), Parution=new DateTime(1862,1,1), Titre="Les misérables"},
                new Livres {Id=4, Auteur=Auteurs.listeDesAuteurs.Find(a=> a.Id==3), Parution=new DateTime(1942,1,1), Titre="L'étranger"},
                new Livres {Id=5, Auteur=Auteurs.listeDesAuteurs.Find(a=> a.Id==3), Parution=new DateTime(1947,1,1), Titre="La peste"}
            };*/
        }
    }
}