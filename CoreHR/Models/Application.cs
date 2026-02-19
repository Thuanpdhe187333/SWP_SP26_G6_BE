using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class Application
{
    public string Id { get; set; } = null!;

    public string? JobId { get; set; }

    public double? TotalScore { get; set; }

    public string? Status { get; set; }

    public DateTime? AppliedAt { get; set; }

    public string? CvFileUrl { get; set; }

    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    public virtual JobPosting? Job { get; set; }

    public virtual ICollection<ScreeningDetail> ScreeningDetails { get; set; } = new List<ScreeningDetail>();
}
