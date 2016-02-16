using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MaBiblio.ViewModels;

namespace MaBiblio.Models
{
    public class DalEnDur : IDal
    {
        private List<Auteur> listeDesAuteurs;
        private List<Livre> listeDesLivres;
        private List<Client> listeDesClients;
        private List<Emprunt> listeDesEmprunts;

        public DalEnDur()
        {
            listeDesAuteurs = new List<Auteur>
            {
                new Auteur {Id=1, Nom="Jules Verne"},
                new Auteur {Id=2, Nom="Victor Hugo"},
                new Auteur {Id=3, Nom="Albert Camus"}
            };

            listeDesLivres = new List<Livre>
            {
                new Livre {Id=1, Auteur=listeDesAuteurs.Find(a => a.Id==1), Parution=new DateTime(1865,1,1), Titre="De la terre à la lune"},
                new Livre {Id=2, Auteur=listeDesAuteurs.Find(a => a.Id==1), Parution=new DateTime(1864,1,1), Titre="Voyage au centre de la terre"},
                new Livre {Id=3, Auteur=listeDesAuteurs.Find(a => a.Id==2), Parution=new DateTime(1862,1,1), Titre="Les misérables"},
                new Livre {Id=4, Auteur=listeDesAuteurs.Find(a => a.Id==3), Parution=new DateTime(1942,1,1), Titre="L'étranger"},
                new Livre {Id=5, Auteur=listeDesAuteurs.Find(a => a.Id==3), Parution=new DateTime(1947,1,1), Titre="La peste"}
            };

            listeDesClients = new List<Client>
            {
                new Client {Email="client1@gmail.com", Nom="M. Client1"},
                new Client {Email="client2@gmail.com", Nom="Mlle Client2"}
            };

            listeDesEmprunts = new List<Emprunt>
            {
                new Emprunt {Client=listeDesClients.Find(c => c.Email=="client1@gmail.com"), Livre=listeDesLivres.Find(l => l.Id==2)},
                new Emprunt {Client=listeDesClients.Find(c => c.Email=="client2@gmail.com"), Livre=listeDesLivres.Find(l => l.Id==4)},
                new Emprunt {Client=listeDesClients.Find(c => c.Email=="client2@gmail.com"), Livre=listeDesLivres.Find(l => l.Id==5)}
            };
       }

        public List<Livre> ObtenirTousLesLivres()
        {
            return listeDesLivres;
        }

        public List<Livre> ObtenirTousLesLivres(int id)
        {
            List<Livre> listeDesLivresDUnAuteur = new List<Livre>();
            foreach (Livre livre in listeDesLivres.Where(l=>l.Auteur.Id==id))
            {
                listeDesLivresDUnAuteur.Add(livre);
            }
            return listeDesLivresDUnAuteur;
        }

        public List<Auteur> ObtenirTousLesAuteurs()
        {
            return listeDesAuteurs;
        }

        public LivreEmprunt ObtenirUnLivre(int id)
        {
            LivreEmprunt livre=new LivreEmprunt();
            livre.Livre = listeDesLivres.Find(l => l.Id == id);
            if (listeDesEmprunts.Exists(e => e.Livre.Id == livre.Livre.Id))
                livre.Emprunteur = listeDesEmprunts.Find(e => e.Livre.Id == livre.Livre.Id).Client;
            else
            {
                livre.Emprunteur = new Client();
                livre.Emprunteur.Nom = "Disponible";
            }

            return livre;
          }

        public void Dispose()
        {
            listeDesLivres = new List<Livre>();
            listeDesEmprunts = new List<Emprunt>();
            listeDesClients = new List<Client>();
            listeDesAuteurs = new List<Auteur>();
        }
    }
}