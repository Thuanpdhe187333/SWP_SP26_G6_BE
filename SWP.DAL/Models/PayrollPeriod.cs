using System;
using System.Collections.Generic;

namespace SWP.DAL.Models;

public partial class PayrollPeriod
{
    public int PeriodId { get; set; }

    public string? PeriodName { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<AttendanceSummary> AttendanceSummaries { get; set; } = new List<AttendanceSummary>();

    public virtual ICollection<KpiEvaluation> KpiEvaluations { get; set; } = new List<KpiEvaluation>();

    public virtual ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();
}
