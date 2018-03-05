using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChoiseManagement.Models.Hotel
{
    public class DTOlogin
    {
        [StringLength(150)]
        [Required(ErrorMessage = "Please enter your Email")]
        [EmailAddress]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Guest_Email { get; set; }
        [Required(ErrorMessage = "Enter password")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]

        public string Paasword { get; set; }
    }
}