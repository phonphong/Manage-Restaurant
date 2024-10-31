using System.Collections.Generic;
using System.Threading.Tasks;
using Management_Restaurant.RestaurantManage.api.@internal.core.entity;

namespace Management_Restaurant.RestaurantManage.api.@internal.core.service
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomersAsync(); // Lấy tất cả khách hàng
        Task<Customer> GetCustomerByIdAsync(int id); // Lấy khách hàng theo ID
        Task<Customer> CreateCustomerAsync(Customer customer); // Tạo khách hàng mới
        Task<Customer> UpdateCustomerAsync(Customer customer); // Cập nhật khách hàng
        Task<bool> DeleteCustomerAsync(int id); // Xóa khách hàng
    }
}
