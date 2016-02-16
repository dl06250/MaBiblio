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
        List<Livre> ObtenirTousLesLivres(int id);
        List<Auteur> ObtenirTousLesAuteurs();
        LivreEmprunt ObtenirUnLivre(int id);
    }
}
