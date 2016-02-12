using MaBiblio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaBiblio.Controllers
{
    public class AfficherController : Controller
    {
        /*
        private IDal dal;

        public AfficherController() : this(new DalEnDur())
        {
        }

        public AfficherController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        */
        //
        // GET: /Afficher/

        public ActionResult Index()
        {
            return View(Livres.listeDesLivres);
        }

    }
}
