﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HotelModel : DbContext
    {
        public HotelModel()
            : base("name=HotelModel")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin_login> Admin_login { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Event_GuestDetails> Event_GuestDetails { get; set; }
        public virtual DbSet<EventReservation> EventReservations { get; set; }
        public virtual DbSet<Food_Categories> Food_Categories { get; set; }
        public virtual DbSet<Food_Items> Food_Items { get; set; }
        public virtual DbSet<Guest_Details> Guest_Details { get; set; }
        public virtual DbSet<Hall> Halls { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Room_Catagorys> Room_Catagorys { get; set; }
        public virtual DbSet<RoomBooking> RoomBookings { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
    }
}
