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
        {
            dal = DalEnDur.Instance;
        }
        
        //
        // GET: /Afficher/
        //Affiche la liste des livres
        public ActionResult Afficher()
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
            if (!dal.ObtenirTousLesAuteurs().Exists(a => a.Id == id))
            {
                ViewData["message"] = "L'auteur '"+id.ToString()+"' n'existe pas dans la base.";
                return View("Error");
            }

            List<Livre> listeDesLivres = dal.ObtenirTousLesLivres().FindAll(l => l.Auteur.Id == id);     
            return View(listeDesLivres);
        }

        //
        // GET: /Afficher/Livre/{idLivre}
        // Affiche la fiche d'un livre
        // On utilise livreEmprunte pour ajouter le nom de l'emprunteur si besoin
        public ActionResult Livre(int id)
        {
            Livre livreDisponible = dal.ObtenirTousLesLivres().Find(d => d.Id == id);
            if (livreDisponible == null)
            {
                ViewData["message"] = "Le livre '" + id.ToString() + "' n'existe pas dans la base.";
                return View("Error");
            }

            LivreEmprunt livreEmprunte = new LivreEmprunt();
            livreEmprunte = dal.ObtenirTousLesLivresEmpruntes().Find(e => e.Livre.Id == id);

            if (livreEmprunte == null)
            {
                livreEmprunte = new LivreEmprunt();
                livreEmprunte.Livre = livreDisponible;
            }

            return View(livreEmprunte);
        }

    }
}
