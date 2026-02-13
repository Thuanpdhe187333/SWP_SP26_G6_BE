using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class JobPosting
{
    public string Id { get; set; } = null!;

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Requirements { get; set; }

    public string? SalaryRange { get; set; }

    public string? Status { get; set; }

    public string? PublishedAt { get; set; }

    public string? RequestId { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual RecruitmentRequest? Request { get; set; }
}
