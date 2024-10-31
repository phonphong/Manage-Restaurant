using Management_Restaurant.RestaurantManage.api.@internal.core.data.repository;
using Management_Restaurant.RestaurantManage.api.@internal.core.entity;
using Management_Restaurant.RestaurantManage.api.@internal.core.dto;
using Microsoft.EntityFrameworkCore;

public class FeedbackService : IFeedbackService
{
    private readonly ApplicationDbContext _context;

    public FeedbackService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Lấy danh sách tất cả phản hồi
    public async Task<List<FeedbackDto>> GetAllFeedbacksAsync()
    {
        return await _context.Feedbacks
            .Select(f => new FeedbackDto
            {
                Id = f.Id,
                UserId = f.UserId,
                Message = f.Message,
                CreatedAt = f.CreatedAt
            })
            .ToListAsync();
    }

    // Lấy phản hồi theo ID
    public async Task<FeedbackDto> GetFeedbackByIdAsync(int id)
    {
        var feedback = await _context.Feedbacks.FindAsync(id);
        if (feedback == null)
        {
            return null; // Hoặc ném ra ngoại lệ nếu cần
        }
        
        return new FeedbackDto
        {
            Id = feedback.Id,
            UserId = feedback.UserId,
            Message = feedback.Message,
            CreatedAt = feedback.CreatedAt
        };
    }

    // Thêm phản hồi mới
    public async Task<FeedbackDto> AddFeedbackAsync(FeedbackDto feedbackDto)
    {
        var feedback = new Feedback
        {
            UserId = feedbackDto.UserId,
            Message = feedbackDto.Message,
            CreatedAt = DateTime.UtcNow
        };

        _context.Feedbacks.Add(feedback);
        await _context.SaveChangesAsync();

        feedbackDto.Id = feedback.Id; // Gán ID cho DTO
        feedbackDto.CreatedAt = feedback.CreatedAt; // Gán thời gian tạo

        return feedbackDto;
    }

    // Cập nhật phản hồi
    public async Task<bool> UpdateFeedbackAsync(int id, FeedbackDto feedbackDto)
    {
        var feedback = await _context.Feedbacks.FindAsync(id);
        if (feedback == null)
        {
            return false; // Không tìm thấy phản hồi
        }

        feedback.Message = feedbackDto.Message;
        await _context.SaveChangesAsync();
        return true; // Cập nhật thành công
    }

    // Xóa phản hồi
    public async Task<bool> DeleteFeedbackAsync(int id)
    {
        var feedback = await _context.Feedbacks.FindAsync(id);
        if (feedback == null)
        {
            return false; // Không tìm thấy phản hồi
        }

        _context.Feedbacks.Remove(feedback);
        await _context.SaveChangesAsync();
        return true; // Xóa thành công
    }
}
