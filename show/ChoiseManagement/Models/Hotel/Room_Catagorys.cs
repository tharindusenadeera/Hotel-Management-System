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

    public partial class Room_Catagorys
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room_Catagorys()
        {
            this.Rooms = new HashSet<Room>();
        }
    
        public int Room_Catogory_Id { get; set; }
        [DisplayName("Room Category ID")]
        public string Room_Catogory { get; set; }
        [DisplayName("Room Category")]
        public string Room_Description { get; set; }
        [DisplayName("Room Description")]
        public string Image_Url { get; set; }
        [DisplayName("Image URL")]
        public bool? IsActive { get; set; }
        [DisplayName("AC Active")]
        public Nullable<int> LCD_Television { get; set; }
        [DisplayName("LCD TV")]
        public Nullable<int> DvdPlayer { get; set; }
        [DisplayName("DVD Player")]
        public Nullable<int> RoomServices { get; set; }
        [DisplayName("Room Service")]
        public Nullable<int> MiniBar { get; set; }
        [DisplayName("Mini Bar")]
        public Nullable<int> WiFi { get; set; }
        [DisplayName("WiFi")]
        public Nullable<int> HairDrier { get; set; }
        [DisplayName("Hair Drier")]

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}