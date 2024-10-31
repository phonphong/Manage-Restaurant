
using Management_Restaurant.RestaurantManage.api.@internal.core.dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management_Restaurant.RestaurantManage.api.@internal.core.service
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> CreateUserAsync(UserDto userDto);
        Task <UserDto>UpdateUserAsync(int id, UserDto userDto);
        Task DeleteUserAsync(int id);
    }
}
