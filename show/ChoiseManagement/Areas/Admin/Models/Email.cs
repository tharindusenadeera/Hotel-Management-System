using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChoiseManagement.Areas.Admin.Models
{
    public class Email
    {
        [StringLength(150)]
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.Text)]
        
        [Display(Name = "sender")]
        public string Sender { get; set; }
        [StringLength(150)]
        [Required(ErrorMessage = "Subject is required")]
        [DataType(DataType.Text)]
       
        [Display(Name = "Subject")]
        public string Subject { get; set; }
        [StringLength(150)]
        [Required(ErrorMessage = "Subject is required")]
        [DataType(DataType.Text)]
        
        [Display(Name = "Body")]
        public string Body { get; set; }


    }
}