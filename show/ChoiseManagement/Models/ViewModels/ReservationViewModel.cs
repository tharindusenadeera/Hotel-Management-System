using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChoiseManagement.Models.Hotel;

namespace ChoiseManagement.Models.ViewModels
{
    public class ReservationViewModel
    {
        public DTOReservation reseravation { get; set; }
        public Room selectedRoom { get; set; }
    }
}