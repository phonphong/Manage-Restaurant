
using System;

namespace Management_Restaurant.RestaurantManage.api.@internal.core.dto
{
    public class ReservationDto
    {
        public int Id { get; set; } // ID của đặt bàn

        public int CustomerId { get; set; } // ID của khách hàng

        public string CustomerName { get; set; } // Tên của khách hàng (nếu cần)

        public int TableId { get; set; } // ID của bàn

        public string TableName { get; set; } // Tên của bàn (nếu cần)

        public DateTime ReservationDate { get; set; } // Ngày đặt bàn

        public DateTime StartTime { get; set; } // Thời gian bắt đầu đặt bàn

        public DateTime EndTime { get; set; } // Thời gian kết thúc đặt bàn

        // Bạn có thể thêm các thuộc tính khác nếu cần
    }
}
