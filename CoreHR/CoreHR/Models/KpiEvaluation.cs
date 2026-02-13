using System;
using System.Collections.Generic;

namespace CoreHR.Models;

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

    public virtual ICollection<EvaluationResultDetail> EvaluationResultDetails { get; set; } = new List<EvaluationResultDetail>();

    public virtual ICollection<ManagerFeedback> ManagerFeedbacks { get; set; } = new List<ManagerFeedback>();

    public virtual PayrollPeriod? Period { get; set; }

    public virtual User? User { get; set; }
}
