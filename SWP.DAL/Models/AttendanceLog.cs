using System;
using System.Collections.Generic;

namespace SWP.DAL.Models;

public partial class AttendanceLog
{
    public int LogId { get; set; }

    public string UserId { get; set; } = null!;

    public DateTime CheckTime { get; set; }

    public virtual User User { get; set; } = null!;
}
