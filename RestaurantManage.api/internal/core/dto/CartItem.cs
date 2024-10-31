using System.ComponentModel.DataAnnotations;
namespace Management_Restaurant.RestaurantManage.api.@internal.core.dto{
public class CartItemDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
}