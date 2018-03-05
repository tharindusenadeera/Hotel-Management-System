using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChoiseManagement.Models.Hotel;

namespace ChoiseManagement.Models.ViewModels
{
    public class OrderItemViewModel
    {
        public Food_Items Item { get; set; }
        public int Qty { get; set; }
        public int SubTotal { get; set; }
    }
}