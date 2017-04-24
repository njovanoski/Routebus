using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RouteBus.Models
{
    public class Postojki
    {
        [Key]
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Adresa { get; set; }
        public string Lokacija { get; set; }
        [Required]
        public string gMapsCoords { get; set; }
        public int PrevoznikId { get; set; }
        public virtual Prevoznik prevoznik { get; set; }
    }

    public class Prevoznik
    {
        [Key]
        public int PrevoznikId { get; set; }
        public string Ime { get; set; }
        public string Linii { get; set; }
    }
}