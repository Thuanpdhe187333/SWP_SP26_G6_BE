using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class RecruitmentRequest
{
    public string Id { get; set; } = null!;

    public string? UserId { get; set; }

    public string? Title { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<JobPosting> JobPostings { get; set; } = new List<JobPosting>();

    public virtual User? User { get; set; }
}
