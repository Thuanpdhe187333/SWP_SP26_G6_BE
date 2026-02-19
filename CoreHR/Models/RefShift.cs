using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class RefShift
{
    public string ShiftId { get; set; } = null!;

    public string ShiftName { get; set; } = null!;

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public double StandardHours { get; set; }

    public bool? IsOvernight { get; set; }

    public virtual ICollection<ShiftRequest> ShiftRequests { get; set; } = new List<ShiftRequest>();

    public virtual ICollection<WorkSchedule> WorkSchedules { get; set; } = new List<WorkSchedule>();
}
