using SWP.BLL.DTOs.Attendance;

namespace SWP.BLL.IService
{
    public interface IAttendanceService
    {
        /// <summary>
        /// Ghi nhận check-in hoặc check-out (tự động xác định dựa trên số lượng log trong ngày)
        /// </summary>
        CheckResponseDto Check(string userId);

        /// <summary>
        /// Lấy thông tin chấm công hôm nay của user
        /// </summary>
        TodayAttendanceDto GetTodayAttendance(string userId);
    }
}
