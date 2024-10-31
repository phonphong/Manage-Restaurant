using Management_Restaurant.RestaurantManage.api.@internal.core.data.repository;
using Management_Restaurant.RestaurantManage.api.@internal.core.dto;
using Management_Restaurant.RestaurantManage.api.@internal.core.entity;
using Management_Restaurant.RestaurantManage.api.@internal.core.service;
using Microsoft.EntityFrameworkCore;

public class ReservationService : IReservationService
{
    private readonly ApplicationDbContext _context;

    public ReservationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ReservationDto>> GetAllReservationsAsync()
    {
        return await _context.Reservations
            .Include(r => r.Table)
            .Include(r => r.Customer)
            .Select(r => new ReservationDto
            {
                Id = r.Id,
                TableId = r.TableId,
                CustomerId = r.CustomerId,
                ReservationDate = r.ReservationDate,
                TableName = r.Table.Name, // Giả định Table có thuộc tính Name
                CustomerName = r.Customer.Name // Giả định Customer có thuộc tính Name
            })
            .ToListAsync(); // Lấy tất cả đặt bàn
    }

    public async Task<ReservationDto> GetReservationByIdAsync(int id)
    {
        var reservation = await _context.Reservations
            .Include(r => r.Table)
            .Include(r => r.Customer)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (reservation == null)
        {
            throw new KeyNotFoundException($"Reservation with ID {id} not found."); // Ném lỗi nếu không tìm thấy
        }

        return new ReservationDto
        {
            Id = reservation.Id,
            TableId = reservation.TableId,
            CustomerId = reservation.CustomerId,
            ReservationDate = reservation.ReservationDate,
            TableName = reservation.Table.Name,
            CustomerName = reservation.Customer.Name
        }; // Trả về đặt bàn
    }

    public async Task<ReservationDto> CreateReservationAsync(ReservationDto reservationDto)
    {
        if (reservationDto == null)
        {
            throw new ArgumentNullException(nameof(reservationDto), "Reservation cannot be null."); // Kiểm tra null
        }

        var reservation = new Reservation
        {
            TableId = reservationDto.TableId,
            CustomerId = reservationDto.CustomerId,
            ReservationDate = reservationDto.ReservationDate
            // Chuyển đổi thêm các thuộc tính khác nếu có
        };

        await _context.Reservations.AddAsync(reservation); // Thêm đặt bàn mới
        await _context.SaveChangesAsync(); // Lưu thay đổi
        
        reservationDto.Id = reservation.Id; // Cập nhật ID từ entity
        return reservationDto; // Trả về đặt bàn đã tạo
    }

    public async Task<ReservationDto> UpdateReservationAsync(ReservationDto reservationDto)
    {
        if (reservationDto == null)
        {
            throw new ArgumentNullException(nameof(reservationDto), "Reservation cannot be null."); // Kiểm tra null
        }

        var existingReservation = await _context.Reservations.FindAsync(reservationDto.Id);
        if (existingReservation == null)
        {
            throw new KeyNotFoundException($"Reservation with ID {reservationDto.Id} not found."); // Ném lỗi nếu không tìm thấy
        }

        existingReservation.TableId = reservationDto.TableId; // Cập nhật ID bàn
        existingReservation.CustomerId = reservationDto.CustomerId; // Cập nhật ID khách hàng
        existingReservation.ReservationDate = reservationDto.ReservationDate; // Cập nhật ngày đặt bàn

        _context.Reservations.Update(existingReservation); // Cập nhật đặt bàn
        await _context.SaveChangesAsync(); // Lưu thay đổi
        
        return reservationDto; // Trả về đặt bàn đã cập nhật
    }

    public async Task<bool> DeleteReservationAsync(int id)
    {
        var reservation = await _context.Reservations.FindAsync(id);
        if (reservation == null)
        {
            throw new KeyNotFoundException($"Reservation with ID {id} not found."); // Ném lỗi nếu không tìm thấy
        }

        _context.Reservations.Remove(reservation); // Xóa đặt bàn
        await _context.SaveChangesAsync(); // Lưu thay đổi
        return true; // Trả về true nếu xóa thành công
    }
}
