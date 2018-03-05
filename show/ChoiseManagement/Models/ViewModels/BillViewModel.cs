using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChoiseManagement.Models.Hotel;
using System.ComponentModel.DataAnnotations;

namespace ChoiseManagement.Models.ViewModels
{
    public class BillViewModel
    {
        [Key]
        public int InvoiceNo { get; set; }
        public IEnumerable<Reservation> ReservationDetails { get; set; }
        public IEnumerable<Bill> BillDetails { get; set; }
        public IEnumerable<Order> Orderdetails { get; set; }




    }
}