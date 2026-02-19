using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class SalaryPolicy
{
    public int PolicyId { get; set; }

    public string? RoleId { get; set; }

    public decimal? BaseSalary { get; set; }

    public decimal? Otrate { get; set; }

    public decimal? PenaltyRate { get; set; }

    public DateOnly? EffectiveFrom { get; set; }
}
