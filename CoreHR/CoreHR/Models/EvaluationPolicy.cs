using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class EvaluationPolicy
{
    public int PolicyId { get; set; }

    public int? PeriodId { get; set; }

    public string? PolicyName { get; set; }

    public string? PolicyDescription { get; set; }

    public virtual PayrollPeriod? Period { get; set; }
}
