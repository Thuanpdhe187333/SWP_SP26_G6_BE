using System;
using System.Collections.Generic;

namespace SWP.DAL.Models;

public partial class KpiEvaluation
{
    public int EvaluationId { get; set; }

    public string? UserId { get; set; }

    public int? PeriodId { get; set; }

    public decimal? TotalScore { get; set; }

    public decimal? BonusAmount { get; set; }

    public string? EvaluatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User? EvaluatedByNavigation { get; set; }

    public virtual PayrollPeriod? Period { get; set; }

    public virtual User? User { get; set; }
}
