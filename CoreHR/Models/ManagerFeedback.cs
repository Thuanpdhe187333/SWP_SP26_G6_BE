using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class ManagerFeedback
{
    public int FeedbackId { get; set; }

    public int? EvaluationId { get; set; }

    public string? ManagerId { get; set; }

    public string? FeedbackContent { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual KpiEvaluation? Evaluation { get; set; }

    public virtual User? Manager { get; set; }
}
