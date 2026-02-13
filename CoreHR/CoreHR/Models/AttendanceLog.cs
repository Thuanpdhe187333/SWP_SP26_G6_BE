using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class AttendanceLog
{
    public int LogId { get; set; }

    public string UserId { get; set; } = null!;

    public DateTime CheckTime { get; set; }

    public virtual User User { get; set; } = null!;
}
