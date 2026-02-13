using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class ShiftRequest
{
    public int RequestId { get; set; }

    public string UserId { get; set; } = null!;

    public string ShiftId { get; set; } = null!;

    public DateOnly Date { get; set; }

    public string? Note { get; set; }

    public string Status { get; set; } = null!;

    public string? ApprovedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual User? ApprovedByNavigation { get; set; }

    public virtual RefShift Shift { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
