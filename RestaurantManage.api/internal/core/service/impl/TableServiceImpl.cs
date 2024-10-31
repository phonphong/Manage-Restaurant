using Management_Restaurant.RestaurantManage.api.@internal.core.data.repository;
using Management_Restaurant.RestaurantManage.api.@internal.core.entity;
using Management_Restaurant.RestaurantManage.api.@internal.core.service;
using Microsoft.EntityFrameworkCore;

public class TableService : ITableService
{
    private readonly ApplicationDbContext _context;

    public TableService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Table>> GetAllTablesAsync()
    {
        return await _context.Tables.ToListAsync(); 
    }

    public async Task<Table> GetTableByIdAsync(int id)
    {
        var table = await _context.Tables.FindAsync(id);
        if (table == null)
        {
            throw new KeyNotFoundException($"Table with ID {id} not found."); 
        }
        return table; // Trả về bàn
    }

    public async Task<Table> CreateTableAsync(Table table)
    {
        if (table == null)
        {
            throw new ArgumentNullException(nameof(table), "Table cannot be null."); 
        }

        await _context.Tables.AddAsync(table); // Thêm bàn mới
        await _context.SaveChangesAsync(); // Lưu thay đổi
        return table; // Trả về bàn đã tạo
    }

    public async Task<Table> UpdateTableAsync(Table table)
    {
        if (table == null)
        {
            throw new ArgumentNullException(nameof(table), "Table cannot be null."); // Kiểm tra null
        }

        var existingTable = await _context.Tables.FindAsync(table.Id);
        if (existingTable == null)
        {
            throw new KeyNotFoundException($"Table with ID {table.Id} not found."); // Ném lỗi nếu không tìm thấy
        }

        existingTable.Name = table.Name; // Cập nhật tên bàn
        existingTable.Seats = table.Seats; // Cập nhật số ghế
        // Cập nhật thêm các thuộc tính khác nếu có

        _context.Tables.Update(existingTable); // Cập nhật bàn
        await _context.SaveChangesAsync(); // Lưu thay đổi
        return existingTable; // Trả về bàn đã cập nhật
    }

    public async Task<bool> DeleteTableAsync(int id)
    {
        var table = await _context.Tables.FindAsync(id);
        if (table == null)
        {
            throw new KeyNotFoundException($"Table with ID {id} not found."); // Ném lỗi nếu không tìm thấy
        }

        _context.Tables.Remove(table); // Xóa bàn
        await _context.SaveChangesAsync(); // Lưu thay đổi
        return true; // Trả về true nếu xóa thành công
    }
}
