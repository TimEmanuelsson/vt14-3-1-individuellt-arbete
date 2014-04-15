using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.Model
{
    public class Medlem
    {
        public int Medid { get; set; }

        [Required(ErrorMessage = "Förnamn måste anges!")]
        [StringLength(30, ErrorMessage = "Förnamnet kan max bestå av 30 tecken!")]
        public string FNamn { get; set; }

        [Required(ErrorMessage = "Efternamn måste anges!")]
        [StringLength(30, ErrorMessage = "Efternamnet kan max bestå av 30 tecken!")]
        public string ENamn { get; set; }

        [Required(ErrorMessage = "Ålder måste anges!")]
        [RegularExpression(@"^([1-9]|[1-9][1-9]|[1-1][1-5][0-0])$", ErrorMessage = "Åldern måste vara mellan 1-150!")]
        public Int16 Alder { get; set; }

        public int Bandid { get; set; }
        public int Rollid { get; set; }

        public string BandNamn { get; set; }
        public string Rolltyp { get; set; }
    }
}