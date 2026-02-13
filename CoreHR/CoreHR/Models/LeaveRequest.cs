using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class LeaveRequest
{
    public int RequestId { get; set; }

    public string UserId { get; set; } = null!;

    public int LeaveTypeId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? Reason { get; set; }

    public string Status { get; set; } = null!;

    public string? ManagerComment { get; set; }

    public virtual LeaveType LeaveType { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
