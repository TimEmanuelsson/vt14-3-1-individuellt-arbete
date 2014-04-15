using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.Model
{
    public class Band
    {
        public int Bandid { get; set; }

        [Required(ErrorMessage = "Namn måste anges!")]
        [StringLength(30, ErrorMessage = "Namnet kan max bestå av 30 tecken!")]
        public string Namn { get; set; }
    }
}