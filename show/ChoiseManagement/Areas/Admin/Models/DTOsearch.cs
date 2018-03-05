using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChoiseManagement.Areas.Admin.Models
{
    public class DTOsearch
    {
        [StringLength(150)]
        [Required(ErrorMessage = "Enter Name")]
        [DataType(DataType.Text)]

        [Display(Name = "Name")]
        public string Sender { get; set; }
    }
}