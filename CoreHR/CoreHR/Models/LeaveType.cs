using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class LeaveType
{
    public int LeaveTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public bool IsPaid { get; set; }

    public virtual ICollection<LeaveBalance> LeaveBalances { get; set; } = new List<LeaveBalance>();

    public virtual ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
}
