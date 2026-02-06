using System;
using System.Collections.Generic;

namespace SWP.DAL.Models;

public partial class EvaluationCriterion
{
    public int CriteriaId { get; set; }

    public string CriteriaName { get; set; } = null!;

    public string? Description { get; set; }

    public double MaxScore { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<EvaluationConfiguration> EvaluationConfigurations { get; set; } = new List<EvaluationConfiguration>();

    public virtual ICollection<EvaluationDetail> EvaluationDetails { get; set; } = new List<EvaluationDetail>();
}
