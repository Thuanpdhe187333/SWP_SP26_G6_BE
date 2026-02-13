using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class Payslip
{
    public int PayslipId { get; set; }

    public int? PayrollId { get; set; }

    public string? FileUrl { get; set; }

    public DateTime? GeneratedAt { get; set; }

    public virtual Payroll? Payroll { get; set; }
}
