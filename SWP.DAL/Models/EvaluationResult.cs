using System;
using System.Collections.Generic;

namespace SWP.DAL.Models;

public partial class EvaluationResult
{
    public int ResultId { get; set; }

    public int AssignmentId { get; set; }

    public double? TotalScore { get; set; }

    public string? Conclusion { get; set; }

    public string? ManagerFeedback { get; set; }

    public DateTime? SubmittedAt { get; set; }

    public DateTime? ClosedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual EvaluationAssignment Assignment { get; set; } = null!;
}
