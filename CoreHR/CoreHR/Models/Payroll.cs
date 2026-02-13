using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class Payroll
{
    public int PayrollId { get; set; }

    public string? UserId { get; set; }

    public int? PeriodId { get; set; }

    public decimal? BaseSalary { get; set; }

    public decimal? Otamount { get; set; }

    public decimal? BonusAmount { get; set; }

    public decimal? PenaltyAmount { get; set; }

    public decimal? NetSalary { get; set; }

    public string? CalculatedBy { get; set; }

    public DateTime? PaidAt { get; set; }

    public virtual User? CalculatedByNavigation { get; set; }

    public virtual ICollection<PayrollItem> PayrollItems { get; set; } = new List<PayrollItem>();

    public virtual ICollection<Payslip> Payslips { get; set; } = new List<Payslip>();

    public virtual PayrollPeriod? Period { get; set; }

    public virtual User? User { get; set; }
}
