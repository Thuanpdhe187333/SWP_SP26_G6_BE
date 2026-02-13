using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class EvaluationCriterion
{
    public int CriteriaId { get; set; }

    public string? CriteriaName { get; set; }

    public string? Description { get; set; }

    public int? MaxScore { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<EvaluationResultDetail> EvaluationResultDetails { get; set; } = new List<EvaluationResultDetail>();

    public virtual ICollection<EvaluationWeight> EvaluationWeights { get; set; } = new List<EvaluationWeight>();
}
