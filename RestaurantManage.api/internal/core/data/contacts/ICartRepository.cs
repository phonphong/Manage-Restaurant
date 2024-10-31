using Management_Restaurant.RestaurantManage.api.@internal.core.entity;

namespace Management_Restaurant.RestaurantManage.api.@internal.core.data.contacts
{
    public interface ICartRepository 
    {
        Task<Cart> GetCartByUserIdAsync(int userId);
    }
}
