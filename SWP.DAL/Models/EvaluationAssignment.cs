using System;
using System.Collections.Generic;

namespace SWP.DAL.Models;

public partial class EvaluationAssignment
{
    public int AssignmentId { get; set; }

    public int PeriodId { get; set; }

    public string ManagerId { get; set; } = null!;

    public string EmployeeId { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User Employee { get; set; } = null!;

    public virtual ICollection<EvaluationComment> EvaluationComments { get; set; } = new List<EvaluationComment>();

    public virtual ICollection<EvaluationDetail> EvaluationDetails { get; set; } = new List<EvaluationDetail>();

    public virtual ICollection<EvaluationHistory> EvaluationHistories { get; set; } = new List<EvaluationHistory>();

    public virtual EvaluationResult? EvaluationResult { get; set; }

    public virtual User Manager { get; set; } = null!;

    public virtual EvaluationPeriod Period { get; set; } = null!;
}
