using Management_Restaurant.RestaurantManage.api.@internal.core.dto;

namespace Management_Restaurant.RestaurantManage.api.@internal.core.service{
public interface ICartService
{
    Task<CartDto> GetCartAsync(int userId);
    Task AddToCartAsync(int userId, CartItemDto cartItemDto);
    Task UpdateCartItemAsync(int userId, CartItemDto cartItemDto);
    Task RemoveFromCartAsync(int userId, int cartItemId);
    Task ClearCartAsync(int userId);
}
}