using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChoiseManagement.Models.Default
{
    public class DTOSearch
    {

        [Required()]
        [DisplayName("Arival Date")]
        [DataType(DataType.Date)]
        public DateTime Arival_Date { get; set; }
        [Required()]
        [DisplayName("Departure Date")]
        [DataType(DataType.Date)]
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