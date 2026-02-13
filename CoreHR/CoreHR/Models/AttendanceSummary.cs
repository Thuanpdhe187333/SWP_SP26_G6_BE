using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class AttendanceSummary
{
    public int SummaryId { get; set; }

    public string? UserId { get; set; }

    public int? PeriodId { get; set; }

    public int? TotalWorkingDays { get; set; }

    public decimal? TotalWorkingHours { get; set; }

    public decimal? TotalOthours { get; set; }

    public int? LateMinutes { get; set; }

    public int? AbsentDays { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual PayrollPeriod? Period { get; set; }

    public virtual User? User { get; set; }
}
