using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChoiseManagement.Models.Hotel;

namespace ChoiseManagement.Models.ViewModels
{
    public class OrderViewModel
    {
        public IEnumerable<Food_Categories> NavBarCategories { get; set; }
        public IEnumerable<Food_Items> foods { get; set; }
    }
}