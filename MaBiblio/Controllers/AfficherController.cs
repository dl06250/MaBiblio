using MaBiblio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaBiblio.ViewModels;

namespace MaBiblio.Controllers
{
    public class AfficherController : Controller
    {
        private IDal dal;

        public AfficherController()
            : this(new DalEnDur())
        {
        }

        public AfficherController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        
        //
        // GET: /Afficher/
        //Affiche la liste des livres
        public ActionResult Livres()
        {
            List<Livre> listeDesLivres = dal.ObtenirTousLesLivres();
            return View(listeDesLivres);
        }

        //
        // GET: /Afficher/Auteurs
        // Affiche la liste des auteurs
        public ActionResult Auteurs()
        {
            List<Auteur> listeDesAuteurs = dal.ObtenirTousLesAuteurs();
            return View(listeDesAuteurs);
        }

        //
        // GET: /Afficher/Auteur/{idAuteur}
        // Affiche la liste des livres d'un auteur
        public ActionResult Auteur(int id)
        {
            List<Livre> listeDesLivres = dal.ObtenirTousLesLivres(id);
            return View(listeDesLivres);
        }

        //
        // GET: /Afficher/Livre/{idLivre}
        // Affiche la fiche d'un livre
        public ActionResult Livre(int id)
        {
            LivreEmprunt livre = dal.ObtenirUnLivre(id);
            return View(livre);
        }

    }
}
