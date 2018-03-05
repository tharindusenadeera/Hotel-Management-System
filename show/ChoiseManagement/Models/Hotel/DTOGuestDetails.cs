using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChoiseManagement.Models.Hotel
{
    public partial class DTOGuestDetails
    {
        [Key]
        [Required(ErrorMessage = "please select your title")]
        [DisplayName("Title")]
        public string Guest_Title { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [RegularExpression(("^[a-zA-Z ]*$"), ErrorMessage = "Your Name Cannot Contain numbers or special Charcters")]
        public string Guest_First_Name { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("Last Name")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [RegularExpression(("^[a-zA-Z ]*$"), ErrorMessage = "Your Name Cannot Contain numbers or special Charcters")]
        public string Guest_Last_Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [DisplayName("Address")]
        [DataType(DataType.Text)]
        public string Guest_Address { get; set; }
       
        [StringLength(150)]
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Guest_Email { get; set; }

        [Required(ErrorMessage = "Your must provide a PhoneNumber")]
        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string PhoneNumber { get; set; }
        

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}