using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class PayrollPeriod
{
    public int PeriodId { get; set; }

    public string? PeriodName { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<AttendanceSummary> AttendanceSummaries { get; set; } = new List<AttendanceSummary>();

    public virtual ICollection<EvaluationAssignment> EvaluationAssignments { get; set; } = new List<EvaluationAssignment>();

    public virtual ICollection<EvaluationPolicy> EvaluationPolicies { get; set; } = new List<EvaluationPolicy>();

    public virtual ICollection<EvaluationWeight> EvaluationWeights { get; set; } = new List<EvaluationWeight>();

    public virtual ICollection<KpiEvaluation> KpiEvaluations { get; set; } = new List<KpiEvaluation>();

    public virtual ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();
}
