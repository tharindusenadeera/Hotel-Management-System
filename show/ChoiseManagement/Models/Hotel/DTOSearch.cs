using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChoiseManagement.Models.Hotel
{
    public class DTOSearch
    {

        [Required()]
        [DisplayName("Arival Date")]
        [DataType(DataType.Date)]
       // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        public DateTime Arival_Date { get; set; }
        [Required()]
        [DisplayName("Departure Date")]
        [DataType(DataType.Date)]
       // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        public DateTime Departure_Date { get; set; }

            [Required()]
            [DisplayName("Adults")]
            [DataType(DataType.Text)]
            public int Adults { get; set; }
            [Required()]
            [DisplayName("Childrens")]
            [DataType(DataType.Text)]
            public int Childerens { get; set; }
        
    }
}