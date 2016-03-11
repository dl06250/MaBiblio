using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaBiblio.ViewModels;

namespace MaBiblio.Models
{
    public interface IDal : IDisposable
    {
        List<Livre> ObtenirTousLesLivres();
        List<Auteur> ObtenirTousLesAuteurs();
        List<LivreEmprunt> ObtenirTousLesLivresEmpruntes();
        void CreerLivre(string titre, DateTime date, Auteur auteur);
        bool LivreExiste(string titre);
    }
}
