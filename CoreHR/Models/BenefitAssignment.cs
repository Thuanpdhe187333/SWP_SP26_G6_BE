using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class BenefitAssignment
{
    public int BenefitAssignmentId { get; set; }

    public string? UserId { get; set; }

    public string? BenefitName { get; set; }

    public string? BenefitType { get; set; }

    public decimal? Amount { get; set; }

    public DateOnly? EffectiveFrom { get; set; }

    public virtual User? User { get; set; }
}
