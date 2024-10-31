using Management_Restaurant.RestaurantManage.api.@internal.core.data.repository;
using Management_Restaurant.RestaurantManage.api.@internal.core.dto;
using Management_Restaurant.RestaurantManage.api.@internal.core.entity;
using Management_Restaurant.RestaurantManage.api.@internal.core.service;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management_Restaurant.RestaurantManage.api.@internal.core.service.impl
{
    public class UserServiceImpl : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            return await _context.Users
                .Select(user => new UserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    Role = user.Role 
                })
                .ToListAsync();
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role 
            };
        }

        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            if (userDto == null) throw new ArgumentNullException(nameof(userDto));

            var user = new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                Role = userDto.Role 
            };

            user.SetPassword(userDto.Password); 

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            userDto.Id = user.Id; 
            return userDto; 
        }

        public async Task<UserDto> UpdateUserAsync(int id, UserDto userDto)
        {
            if (userDto == null) throw new ArgumentNullException(nameof(userDto));

            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

           
            user.Username = userDto.Username;
            user.Email = userDto.Email;
            user.Role = userDto.Role;

           
            if (!string.IsNullOrEmpty(userDto.Password))
            {
                user.SetPassword(userDto.Password);
            }

            await _context.SaveChangesAsync();

            return userDto; // Trả về DTO của người dùng đã cập nhật
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
