using MaBiblio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaBiblio.Controllers
{
    public class RechercherController : Controller
    {

        private IDal dal;

        public RechercherController()
        {
            dal = DalEnDur.Instance;
        }


        public ActionResult Livre(string str)
        {
            if (String.IsNullOrWhiteSpace(str))
                ViewData["errorMessage"] = "Veuillez indiquez la chaîne à rechercher.";
            else
            {
                ViewData["errorMessage"] = String.Empty;
                ViewData["str"] = str;
            }

            return View();
        }


        [HttpPost]
        [ActionName("Livre")]
        public ActionResult LivrePost(string str)
        {
            if (String.IsNullOrWhiteSpace(str))
                return RedirectToAction("Livre", new { str = str });

            List<Livre> listeDesLivres = dal.ObtenirTousLesLivres().FindAll(l=>l.Titre.ToUpperInvariant().Contains(str.ToUpperInvariant()) || l.Auteur.Nom.ToUpperInvariant().Contains(str.ToUpperInvariant())) ;
            if (listeDesLivres == null || listeDesLivres.Count == 0)
            {
                ViewData["message"] = "Aucun titre ou nom d'auteur ne contient la chaine '" + str + "'.";
                return View("Error");
            }
            return View("~/Views/Afficher/Afficher.cshtml",listeDesLivres);
        }

    }
}
