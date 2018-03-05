//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChoiseManagement.Models.Hotel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Order
    {
        public int Order_Id { get; set; }
        [DisplayName("Order ID")]
        public Nullable<int> Reservation_Id { get; set; }
        [DisplayName("Reservation ID")]
        public Nullable<int> Item_Id { get; set; }
        [DisplayName("Item ID")]
        public Nullable<int> Item_Quantity { get; set; }
        [DisplayName("Item Quantity")]
        public Nullable<int> Item_Portion_Price { get; set; }
        [DisplayName("Item Portion Price")]
        public Nullable<int> Total_Item_Price { get; set; }
        [DisplayName("Total Item Price ")]
        public virtual Food_Items Food_Items { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}