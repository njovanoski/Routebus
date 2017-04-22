using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RouteBus.Models
{
    [MetadataType(typeof(AccountMetadata))]
    public partial class Account
    {
    }

    public class AccountMetadata
    {
        [Required (AllowEmptyStrings= false, ErrorMessage="Vnesete Ime")]
        public string Ime { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vnesete Prezime")]
        public string Prezime { get; set; }
    }
}