using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MaBiblio.Models
{
    public class Emprunt
    {
        public Livre Livre { get; set; }
        public Client Client { get; set; }
    }
}