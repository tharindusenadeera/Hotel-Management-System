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
    
    public partial class EventReservation
    {
        public int EventBookingID { get; set; }
        public Nullable<int> HallNumber { get; set; }
        public Nullable<System.DateTime> EventStartDate { get; set; }
        public Nullable<System.DateTime> EventEndDate { get; set; }
        public Nullable<int> EventReservationId { get; set; }
    
        public virtual Event_GuestDetails Event_GuestDetails { get; set; }
        public virtual Hall Hall { get; set; }
    }
}
