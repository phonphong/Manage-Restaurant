using System.ComponentModel.DataAnnotations;

namespace Management_Restaurant.RestaurantManage.api.@internal.core.dto{
public class CartDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<CartItemDto> Items { get; set; } = new List<CartItemDto>();
    public decimal TotalPrice { get; set; }
}
}