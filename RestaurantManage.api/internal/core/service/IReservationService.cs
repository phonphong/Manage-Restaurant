using System.Collections.Generic;
using System.Threading.Tasks;
using Management_Restaurant.RestaurantManage.api.@internal.core.entity;

namespace Management_Restaurant.RestaurantManage.api.@internal.core.service
{
    public interface IReservationService
    {
        Task<List<Reservation>> GetAllReservationsAsync(); // Lấy tất cả đặt bàn
        Task<Reservation> GetReservationByIdAsync(int id); // Lấy đặt bàn theo ID
        Task<Reservation> CreateReservationAsync(Reservation reservation); // Tạo đặt bàn mới
        Task<Reservation> UpdateReservationAsync(Reservation reservation); // Cập nhật đặt bàn
        Task<bool> DeleteReservationAsync(int id); // Xóa đặt bàn
    }
}
