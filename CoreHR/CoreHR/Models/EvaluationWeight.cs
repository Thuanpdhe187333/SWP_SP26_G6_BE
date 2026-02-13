using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class EvaluationWeight
{
    public int WeightId { get; set; }

    public int? PeriodId { get; set; }

    public int? CriteriaId { get; set; }

    public decimal? WeightPercentage { get; set; }

    public virtual EvaluationCriterion? Criteria { get; set; }

    public virtual PayrollPeriod? Period { get; set; }
}
