using System;
using System.Collections.Generic;

namespace SWP.DAL.Models;

public partial class EvaluationConfiguration
{
    public int ConfigId { get; set; }

    public int PeriodId { get; set; }

    public int CriteriaId { get; set; }

    public double Weight { get; set; }

    public string? Policy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual EvaluationCriterion Criteria { get; set; } = null!;

    public virtual EvaluationPeriod Period { get; set; } = null!;
}
