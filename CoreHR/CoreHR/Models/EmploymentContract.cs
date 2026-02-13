using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class EmploymentContract
{
    public int ContractId { get; set; }

    public string? UserId { get; set; }

    public string? ContractType { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? SalaryType { get; set; }

    public decimal? SalaryRate { get; set; }

    public string? ContractStatus { get; set; }

    public virtual User? User { get; set; }
}
