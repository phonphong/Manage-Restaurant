using Management_Restaurant.RestaurantManage.api.@internal.core.entity;

namespace Management_Restaurant.RestaurantManage.api.@internal.core.data.contacts
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByUsernameAsync(string username);
    }
}
