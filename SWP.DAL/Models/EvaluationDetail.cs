using System;
using System.Collections.Generic;

namespace SWP.DAL.Models;

public partial class EvaluationDetail
{
    public int DetailId { get; set; }

    public int AssignmentId { get; set; }

    public int CriteriaId { get; set; }

    public double? Score { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual EvaluationAssignment Assignment { get; set; } = null!;

    public virtual EvaluationCriterion Criteria { get; set; } = null!;
}
