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
    
    public partial class Bill
    {
        public int Bill_ID { get; set; }
        public Nullable<int> Reservation_ID { get; set; }
        public Nullable<int> Total_Charge { get; set; }
        public Nullable<int> Paid { get; set; }
    }
}
