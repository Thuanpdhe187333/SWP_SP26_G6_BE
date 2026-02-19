using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class InterviewPanel
{
    public string Id { get; set; } = null!;

    public string? UserId { get; set; }

    public string? InterviewId { get; set; }

    public string? Feedback { get; set; }

    public virtual Interview? Interview { get; set; }

    public virtual User? User { get; set; }
}
