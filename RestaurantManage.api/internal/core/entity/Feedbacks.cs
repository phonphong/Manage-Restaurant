using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management_Restaurant.RestaurantManage.api.@internal.core.entity
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; } 

        public virtual required Customer Customer { get; set; } 

        public string Content { get; set; } 

        public DateTime FeedbackDate { get; set; } = DateTime.Now; 
    }
}
