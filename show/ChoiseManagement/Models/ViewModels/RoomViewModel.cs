using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChoiseManagement.Models.Hotel;

namespace ChoiseManagement.Models.ViewModels
{
    public class RoomViewModel
    {
        
        public IEnumerable<Room_Catagorys> catogories { get; set; }
        public IEnumerable<Room> RoomList { get; set; }
        public string nic { get; set; }

    }
}