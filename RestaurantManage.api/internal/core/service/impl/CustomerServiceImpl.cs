using Management_Restaurant.RestaurantManage.api.@internal.core.data.repository;
using Management_Restaurant.RestaurantManage.api.@internal.core.entity;
using Management_Restaurant.RestaurantManage.api.@internal.core.service;
using Microsoft.EntityFrameworkCore;

public class CustomerService : ICustomerService
{
    private readonly ApplicationDbContext _context;

    public CustomerService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetAllCustomersAsync()
    {
        return await _context.Customers.ToListAsync(); // Lấy tất cả khách hàng
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
        {
            throw new KeyNotFoundException($"Customer with ID {id} not found."); // Ném lỗi nếu không tìm thấy
        }
        return customer; // Trả về khách hàng
    }

    public async Task<Customer> CreateCustomerAsync(Customer customer)
    {
        if (customer == null)
        {
            throw new ArgumentNullException(nameof(customer), "Customer cannot be null."); // Kiểm tra null
        }

        await _context.Customers.AddAsync(customer); // Thêm khách hàng mới
        await _context.SaveChangesAsync(); // Lưu thay đổi
        return customer; // Trả về khách hàng đã tạo
    }

    public async Task<Customer> UpdateCustomerAsync(Customer customer)
    {
        if (customer == null)
        {
            throw new ArgumentNullException(nameof(customer), "Customer cannot be null."); // Kiểm tra null
        }

        var existingCustomer = await _context.Customers.FindAsync(customer.Id);
        if (existingCustomer == null)
        {
            throw new KeyNotFoundException($"Customer with ID {customer.Id} not found."); // Ném lỗi nếu không tìm thấy
        }

        existingCustomer.Name = customer.Name; // Cập nhật tên khách hàng
        existingCustomer.Email = customer.Email; // Cập nhật email
        // Cập nhật thêm các thuộc tính khác nếu có

        _context.Customers.Update(existingCustomer); // Cập nhật khách hàng
        await _context.SaveChangesAsync(); // Lưu thay đổi
        return existingCustomer; // Trả về khách hàng đã cập nhật
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
        {
            throw new KeyNotFoundException($"Customer with ID {id} not found."); // Ném lỗi nếu không tìm thấy
        }

        _context.Customers.Remove(customer); // Xóa khách hàng
        await _context.SaveChangesAsync(); // Lưu thay đổi
        return true; // Trả về true nếu xóa thành công
    }
}
