
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management_Restaurant.RestaurantManage.api.@internal.core.entity
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; } 

        public virtual User User { get; set; } 

        public DateTime OrderDate { get; set; } = DateTime.Now; 

        public decimal TotalAmount { get; set; } 

        public OrderStatus Status { get; set; } 

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>(); 
    }

    public enum OrderStatus
    {
        Pending,
        Completed,
        Canceled,
        InProgress
    }
}
