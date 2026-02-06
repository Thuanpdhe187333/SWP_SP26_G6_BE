using System;
using System.Collections.Generic;

namespace SWP.BLL.DTOs.Attendance
{
    public class TodayAttendanceDto
    {
        public List<AttendanceLogDto> Logs { get; set; } = new();
        public bool IsCurrentlyCheckedIn { get; set; }
        public double TotalWorkHours { get; set; }
        public DateTime? FirstCheckIn { get; set; }
        public DateTime? LastCheckOut { get; set; }
    }

    public class AttendanceLogDto
    {
        public int LogId { get; set; }
        public DateTime CheckTime { get; set; }
        public string Type { get; set; } = null!; // "check_in" hoặc "check_out"
    }
}
