using System.Collections.Generic;
using System.Threading.Tasks;
using Management_Restaurant.RestaurantManage.api.@internal.core.entity;

namespace Management_Restaurant.RestaurantManage.api.@internal.core.service
{
    public interface IFeedbackService
    {
        Task<List<Feedback>> GetAllFeedbacksAsync(); // Lấy tất cả phản hồi
        Task<Feedback> GetFeedbackByIdAsync(int id); // Lấy phản hồi theo ID
        Task<Feedback> CreateFeedbackAsync(Feedback feedback); // Tạo phản hồi mới
        Task<Feedback> UpdateFeedbackAsync(Feedback feedback); // Cập nhật phản hồi
        Task<bool> DeleteFeedbackAsync(int id); // Xóa phản hồi
    }
}
