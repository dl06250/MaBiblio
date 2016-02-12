using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MaBiblio.Models
{
    public class Emprunts
    {
        public Livres Livre { get; set; }
        public Clients Client { get; set; }
    }
}