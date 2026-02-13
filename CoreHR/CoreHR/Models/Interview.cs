using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class Interview
{
    public string Id { get; set; } = null!;

    public string? ApplicationId { get; set; }

    public DateTime? ScheduledAt { get; set; }

    public string? Location { get; set; }

    public bool? IsReminderSent { get; set; }

    public bool? Status { get; set; }

    public string? FinalDecision { get; set; }

    public virtual Application? Application { get; set; }

    public virtual ICollection<InterviewPanel> InterviewPanels { get; set; } = new List<InterviewPanel>();
}
