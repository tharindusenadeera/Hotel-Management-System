using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChoiseManagement.Models.Hotel
{
    public partial class DTOReservation
    {
        [Key]

        public int Id { get; set; }
        [Required(ErrorMessage = "You need to chose an Package")]
        [DisplayName("Package")]
        [DataType(DataType.Text)]
        public int Package_Id { get; set; }

        [Required(ErrorMessage = "Checkin Date is need to fill")]
        [DisplayName("Check In Date")]
        [DataType(DataType.Date)]

        public DateTime Check_In { get; set; }

        [Required(ErrorMessage = "Checkin Out is need to fill")]
        [DisplayName("Check Out Date")]
        [DataType(DataType.Date)]
        
        public DateTime Check_Out { get; set; }

        [Required(ErrorMessage = "Please select the No of Adults")]
        [DisplayName("Adults")]
        [DataType(DataType.Text)]
        public int Adults { get; set; }

        [Required(ErrorMessage = "Please select the No of Childrens")]
        [DisplayName("Childrens")]
        [DataType(DataType.Text)]
        public int Childrens { get; set; }

        
}
}