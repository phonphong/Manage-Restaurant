using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management_Restaurant.RestaurantManage.api.@internal.core.entity
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; } 

        public virtual Customer Customer { get; set; } 

        [ForeignKey("Table")]
        public int TableId { get; set; } 

        public virtual Table Table { get; set; } 

        public DateTime ReservationDate { get; set; } 

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; } 
    }
}
