using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RouteBus.Models
{
    public class uAccount
    {
        [Key]
        public int Id { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }
        [Required(ErrorMessage = "Корисничкото име е задолжително!")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Лозинката е задолжителна!")]
        [DataType(DataType.Password)]
        public string pass { get; set; }

        public string role { get; set; }


    }
}