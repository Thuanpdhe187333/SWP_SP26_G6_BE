using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class LeaveBalance
{
    public string UserId { get; set; } = null!;

    public int LeaveTypeId { get; set; }

    public int Year { get; set; }

    public double RemainingDays { get; set; }

    public virtual LeaveType LeaveType { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
