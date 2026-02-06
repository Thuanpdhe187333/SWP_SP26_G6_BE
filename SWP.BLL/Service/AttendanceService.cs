using Microsoft.EntityFrameworkCore;
using SWP.BLL.DTOs.Attendance;
using SWP.BLL.IService;
using SWP.DAL.Models;

namespace SWP.BLL.Service
{
    public class AttendanceService : IAttendanceService
    {
        private readonly HrmSystemContext _context;

        public AttendanceService(HrmSystemContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Ghi nhận check-in hoặc check-out
        /// Logic: Số lẻ = check-in, số chẵn = check-out
        /// </summary>
        public CheckResponseDto Check(string userId)
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            // Đếm số lần check trong ngày
            var todayLogsCount = _context.AttendanceLogs
                .Count(l => l.UserId == userId && l.CheckTime >= today && l.CheckTime < tomorrow);

            // Xác định loại check
            var isCheckIn = todayLogsCount % 2 == 0; // Số chẵn -> check-in tiếp theo
            var checkType = isCheckIn ? "check_in" : "check_out";

            // Tạo log mới
            var newLog = new AttendanceLog
            {
                UserId = userId,
                CheckTime = DateTime.Now
            };

            _context.AttendanceLogs.Add(newLog);
            _context.SaveChanges();

            return new CheckResponseDto
            {
                LogId = newLog.LogId,
                UserId = userId,
                CheckTime = newLog.CheckTime,
                Type = checkType,
                Message = isCheckIn ? "Check-in thành công!" : "Check-out thành công!"
            };
        }

        /// <summary>
        /// Lấy thông tin chấm công hôm nay
        /// </summary>
        public TodayAttendanceDto GetTodayAttendance(string userId)
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            // Lấy tất cả logs hôm nay
            var todayLogs = _context.AttendanceLogs
                .Where(l => l.UserId == userId && l.CheckTime >= today && l.CheckTime < tomorrow)
                .OrderBy(l => l.CheckTime)
                .ToList();

            var result = new TodayAttendanceDto
            {
                Logs = new List<AttendanceLogDto>(),
                IsCurrentlyCheckedIn = todayLogs.Count % 2 == 1, // Số lẻ = đang check-in
                TotalWorkHours = 0,
                FirstCheckIn = null,
                LastCheckOut = null
            };

            // Map logs với type
            for (int i = 0; i < todayLogs.Count; i++)
            {
                var log = todayLogs[i];
                result.Logs.Add(new AttendanceLogDto
                {
                    LogId = log.LogId,
                    CheckTime = log.CheckTime,
                    Type = i % 2 == 0 ? "check_in" : "check_out"
                });
            }

            // Tính thời gian làm việc
            if (todayLogs.Count >= 1)
            {
                result.FirstCheckIn = todayLogs[0].CheckTime;
            }

            double totalMinutes = 0;
            for (int i = 0; i < todayLogs.Count - 1; i += 2)
            {
                var checkIn = todayLogs[i].CheckTime;
                var checkOut = i + 1 < todayLogs.Count ? todayLogs[i + 1].CheckTime : DateTime.Now;
                totalMinutes += (checkOut - checkIn).TotalMinutes;

                if (i + 1 < todayLogs.Count)
                {
                    result.LastCheckOut = todayLogs[i + 1].CheckTime;
                }
            }

            // Nếu đang check-in (chưa check-out), tính đến thời điểm hiện tại
            if (todayLogs.Count % 2 == 1)
            {
                var lastCheckIn = todayLogs[todayLogs.Count - 1].CheckTime;
                totalMinutes += (DateTime.Now - lastCheckIn).TotalMinutes;
            }

            result.TotalWorkHours = Math.Round(totalMinutes / 60, 2);

            return result;
        }
    }
}
