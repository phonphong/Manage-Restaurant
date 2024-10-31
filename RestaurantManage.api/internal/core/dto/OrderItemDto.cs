
using System.ComponentModel.DataAnnotations;

namespace Management_Restaurant.RestaurantManage.api.@internal.core.dto
{
    public class OrderItemDto
    {
        public int Id { get; set; }

        //foreign key order
        public int OrderId { get; set; } 

         //foreign key product
        public int ProductId { get; set; } 

        [Required]
        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
