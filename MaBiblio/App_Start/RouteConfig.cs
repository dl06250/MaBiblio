using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MaBiblio
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AfficherLivreAuteur",
                url: "Afficher/Auteur/{id}",
                defaults: new { controller = "Afficher", action = "Auteur", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AfficherLivre",
                url: "Afficher/Livre/{id}",
                defaults: new { controller = "Afficher", action = "Livre", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AfficherAuteurs",
                url: "Afficher/Auteurs",
                defaults: new { controller = "Afficher", action = "Auteurs"}
            );

            routes.MapRoute(
                name: "AfficherLivres",
                url: "Afficher",
                defaults: new { controller = "Afficher", action = "Afficher"}
            );

            routes.MapRoute(
                name: "RechercheLivre",
                url: "Rechercher/Livre/{str}",
                defaults: new { controller = "Rechercher", action = "Livre", str = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AjoutLivre",
                url: "Ajouter/Livre",
                defaults: new { controller = "Ajouter", action = "Livre"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}