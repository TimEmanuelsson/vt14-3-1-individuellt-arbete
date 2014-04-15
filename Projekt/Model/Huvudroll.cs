using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.Model
{
    public class Huvudroll
    {
        public int Rollid { get; set; }

        [Required(ErrorMessage = "Rolltyp måste anges!")]
        [StringLength(30, ErrorMessage = "Rolltypen kan max bestå av 30 tecken!")]
        public string Rolltyp { get; set; }
    }
}