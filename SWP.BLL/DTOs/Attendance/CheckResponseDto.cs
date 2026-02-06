using System;

namespace SWP.BLL.DTOs.Attendance
{
    public class CheckResponseDto
    {
        public int LogId { get; set; }
        public string UserId { get; set; } = null!;
        public DateTime CheckTime { get; set; }
        public string Type { get; set; } = null!; // "check_in" hoặc "check_out"
        public string Message { get; set; } = null!;
    }
}
