using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MaBiblio.ViewModels;

namespace MaBiblio.Models
{
    public class DalEnDur : IDal
    {
        private static DalEnDur instance;

        private List<Auteur> listeDesAuteurs;
        private List<Livre> listeDesLivres;
        private List<Client> listeDesClients;
        private List<LivreEmprunt> listeLivresEmpruntes;

        public static DalEnDur Instance
        {
            get
            {
                if (instance == null)
                    instance = new DalEnDur();
                return instance;
            }
        }

        private DalEnDur()
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

            listeLivresEmpruntes = new List<LivreEmprunt>
            {
                new LivreEmprunt {Emprunteur=listeDesClients.Find(c => c.Email=="client1@gmail.com"), Livre=listeDesLivres.Find(l => l.Id==2)},
                new LivreEmprunt {Emprunteur=listeDesClients.Find(c => c.Email=="client2@gmail.com"), Livre=listeDesLivres.Find(l => l.Id==4)},
                new LivreEmprunt {Emprunteur=listeDesClients.Find(c => c.Email=="client2@gmail.com"), Livre=listeDesLivres.Find(l => l.Id==5)}
            };
       }

        public List<Livre> ObtenirTousLesLivres()
        {
            return listeDesLivres;
        }

        public List<Auteur> ObtenirTousLesAuteurs()
        {
            return listeDesAuteurs;
        }

        public List<LivreEmprunt> ObtenirTousLesLivresEmpruntes()
        {
            return listeLivresEmpruntes;
        }

        public void Dispose()
        {
            listeDesLivres = new List<Livre>();
            listeDesClients = new List<Client>();
            listeDesAuteurs = new List<Auteur>();
            listeLivresEmpruntes = new List<LivreEmprunt>();
        }


        public void CreerLivre(string titre, DateTime date, Auteur auteur)
        {
            int id = listeDesLivres.Count == 0 ? 1 : listeDesLivres.Max(l => l.Id) + 1;
            listeDesLivres.Add(new Livre { Id = id, Titre = titre, Auteur = auteur, Parution = date });
        }


        public bool LivreExiste(string titre)
        {
            return listeDesLivres.Any(livre => livre.Titre == titre);
        }
    }
}