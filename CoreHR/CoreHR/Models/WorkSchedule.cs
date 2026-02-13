using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class WorkSchedule
{
    public int ScheduleId { get; set; }

    public string UserId { get; set; } = null!;

    public string ShiftId { get; set; } = null!;

    public DateOnly Date { get; set; }

    public double RequestOthours { get; set; }

    public bool IsPublished { get; set; }

    public string? AssignedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual User? AssignedByNavigation { get; set; }

    public virtual ICollection<DailyTimesheet> DailyTimesheets { get; set; } = new List<DailyTimesheet>();

    public virtual RefShift Shift { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
