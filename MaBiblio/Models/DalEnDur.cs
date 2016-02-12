using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaBiblio.Models
{
    public class DalEnDur : IDal
    {
        private List<Livres> listeDesLivres;
        private List<Auteurs> listeDesAuteurs;
        private List<Clients> listeDesClients;
        private List<Emprunts> listeDesEmprunts;

        public DalEnDur()
        {
            listeDesAuteurs = new List<Auteurs>
            {
                new Auteurs {Id=1, Nom="Jules Verne"},
                new Auteurs {Id=2, Nom="Victor Hugo"},
                new Auteurs {Id=3, Nom="Albert Camus"}
            };

            listeDesLivres=new List<Livres>
            {
                new Livres {Id=1, Auteur=listeDesAuteurs.Find(a => a.Id==1), Parution=new DateTime(1865,1,1), Titre="De la terre à la lune"},
                new Livres {Id=2, Auteur=listeDesAuteurs.Find(a => a.Id==1), Parution=new DateTime(1864,1,1), Titre="Voyage au centre de la terre"},
                new Livres {Id=3, Auteur=listeDesAuteurs.Find(a=> a.Id==2), Parution=new DateTime(1862,1,1), Titre="Les misérables"},
                new Livres {Id=4, Auteur=listeDesAuteurs.Find(a=> a.Id==3), Parution=new DateTime(1942,1,1), Titre="L'étranger"},
                new Livres {Id=5, Auteur=listeDesAuteurs.Find(a=> a.Id==3), Parution=new DateTime(1947,1,1), Titre="La peste"}
            };

            listeDesClients = new List<Clients>
            {
                new Clients {Email="client1@gmail.com", Nom="M. Client1"},
                new Clients {Email="client2@gmail.com", Nom="Mlle Client2"}
            };

            listeDesEmprunts = new List<Emprunts>
            {
                new Emprunts {Client=listeDesClients.Find(c => c.Email=="client1@gmail.com"), Livre=listeDesLivres.Find(l => l.Id==2)},
                new Emprunts {Client=listeDesClients.Find(c => c.Email=="client2@gmail.com"), Livre=listeDesLivres.Find(l => l.Id==4)},
                new Emprunts {Client=listeDesClients.Find(c => c.Email=="client2@gmail.com"), Livre=listeDesLivres.Find(l => l.Id==5)}
            };
       }

        public List<Livres> ObtenirTousLesLivres()
        {
            return listeDesLivres;
        }

        public List<Livres> ObtenirTousLesLivres(int id)
        {
            List<Livres> listeDesLivresDUnAuteur = new List<Livres>();
            foreach (Livres livre in listeDesLivres.Where(l=>l.Auteur.Id==id))
            {
                listeDesLivresDUnAuteur.Add(livre);
            }
            return listeDesLivresDUnAuteur;
        }

        public List<Auteurs> ObtenirTousLesAuteurs()
        {
            return listeDesAuteurs;
        }

        public Livres ObtenirUnLivre(int id)
        {
            return listeDesLivres.FirstOrDefault(l => l.Id == id);
        }

        public void Dispose()
        {
            listeDesLivres = new List<Livres>();
            listeDesEmprunts = new List<Emprunts>();
            listeDesClients = new List<Clients>();
            listeDesAuteurs = new List<Auteurs>();
        }
    }
}