
using System.ComponentModel.DataAnnotations;
using Management_Restaurant.RestaurantManage.api.@internal.core.entity;

namespace Management_Restaurant.RestaurantManage.api.@internal.core.dto
{
    public class OrderDto
    {
        public int Id { get; set; }


         //foreign key userOrder
        public int UserId { get; set; } 

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public OrderStatus Status { get; set; }
    }
}
