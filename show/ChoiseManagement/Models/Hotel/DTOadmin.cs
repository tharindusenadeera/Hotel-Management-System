﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChoiseManagement.Models.Hotel
{
    public class DTOadmin
    {
        [Key]
        [StringLength(150)]
        [Required(ErrorMessage = "Please enter your user name")]
        
        [DisplayName("User Name")]
        [DataType(DataType.Text)]
        public string Guest_Email { get; set; }

        [Required(ErrorMessage = "Please Enter password")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]

        public string Paasword { get; set; }
    }
}