using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class PayrollItem
{
    public int ItemId { get; set; }

    public int? PayrollId { get; set; }

    public string? ItemType { get; set; }

    public string? Description { get; set; }

    public decimal? Amount { get; set; }

    public virtual Payroll? Payroll { get; set; }
}
