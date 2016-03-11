using MaBiblio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaBiblio.ViewModels
{
    public class LivreAjout
    {
        [Required(ErrorMessage = "Le titre du livre doit être saisi")]
        public string Titre { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date de parution")]
        [DataType(DataType.Date)]
        public DateTime Parution { get; set; }

        [Display(Name="Auteur")]
        public int AuteurSelectionneId { get; set; }

        public List<Auteur> ListeDesAuteurs = DalEnDur.Instance.ObtenirTousLesAuteurs();
    }
}