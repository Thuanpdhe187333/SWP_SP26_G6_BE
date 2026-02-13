using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class DailyTimesheet
{
    public int TimesheetId { get; set; }

    public string UserId { get; set; } = null!;

    public int ScheduleId { get; set; }

    public DateOnly Date { get; set; }

    public DateTime? RealCheckIn { get; set; }

    public DateTime? RealCheckOut { get; set; }

    public double? WorkingHours { get; set; }

    public double? ActualOthours { get; set; }

    public int? LateMinutes { get; set; }

    public int? EarlyLeaveMinutes { get; set; }

    public string Status { get; set; } = null!;

    public virtual WorkSchedule Schedule { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
