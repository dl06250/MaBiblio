using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaBiblio.Models
{
    public interface IDal : IDisposable
    {
        List<Livres> ObtenirTousLesLivres();
        List<Livres> ObtenirTousLesLivres(int id);
        List<Auteurs> ObtenirTousLesAuteurs();
        Livres ObtenirUnLivre(int id);
    }
}
