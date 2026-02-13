using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class EvaluationResultDetail
{
    public int DetailId { get; set; }

    public int? EvaluationId { get; set; }

    public int? CriteriaId { get; set; }

    public decimal? Score { get; set; }

    public string? Comment { get; set; }

    public virtual EvaluationCriterion? Criteria { get; set; }

    public virtual KpiEvaluation? Evaluation { get; set; }
}
