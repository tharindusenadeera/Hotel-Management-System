using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChoiseManagement.Models.Hotel;

namespace ChoiseManagement.Models.ViewModels
{
    public class ReserveRoomViewModel
    {
        public Room SelectedRoom { get; set; }
        public DTOReservation ReservationDetails { get; set; }
    }
}