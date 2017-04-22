using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RouteBus.Models
{
    public class Accounts
    {
        [Key]
        public int id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string userName { get; set; }
        public string pass { get; set; }
        public string role { get; set; }
    }
}