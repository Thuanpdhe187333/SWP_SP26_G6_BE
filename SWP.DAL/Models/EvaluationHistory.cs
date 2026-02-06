using System;
using System.Collections.Generic;

namespace SWP.DAL.Models;

public partial class EvaluationHistory
{
    public int HistoryId { get; set; }

    public int AssignmentId { get; set; }

    public string Action { get; set; } = null!;

    public string ChangedBy { get; set; } = null!;

    public string? OldValue { get; set; }

    public string? NewValue { get; set; }

    public DateTime? ChangedAt { get; set; }

    public virtual EvaluationAssignment Assignment { get; set; } = null!;

    public virtual User ChangedByNavigation { get; set; } = null!;
}
