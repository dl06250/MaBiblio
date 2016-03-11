using MaBiblio.Models;
using MaBiblio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaBiblio.Controllers
{
    public class AjouterController : Controller
    {
        private IDal dal;

        public AjouterController()
        {
            dal = DalEnDur.Instance;
        }

        //
        // GET: /Ajouter/

        public ActionResult Livre()
        {
            LivreAjout livreAjout = new LivreAjout();
            return View(livreAjout);
        }

        [HttpPost]
        public ActionResult Livre(LivreAjout livre)
        {
            if (dal.LivreExiste(livre.Titre))
            {
                ModelState.AddModelError("Titre", "Ce titre de livre est déjà présent dans la bibliothèque");
                return View(livre);
            }
            if (!ModelState.IsValid)
                return View(livre);

            Auteur auteur = dal.ObtenirTousLesAuteurs().Find(a => a.Id == livre.AuteurSelectionneId);

            dal.CreerLivre(livre.Titre, livre.Parution, auteur);
            return RedirectToAction("Afficher", "Afficher");
        }


    }
}
