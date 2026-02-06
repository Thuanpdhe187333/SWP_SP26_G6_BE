using System;
using System.Collections.Generic;

namespace SWP.DAL.Models;

public partial class EvaluationPeriod
{
    public int PeriodId { get; set; }

    public string PeriodName { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string Status { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<EvaluationAssignment> EvaluationAssignments { get; set; } = new List<EvaluationAssignment>();

    public virtual ICollection<EvaluationConfiguration> EvaluationConfigurations { get; set; } = new List<EvaluationConfiguration>();
}
