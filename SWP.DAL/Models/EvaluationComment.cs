using System;
using System.Collections.Generic;

namespace SWP.DAL.Models;

public partial class EvaluationComment
{
    public int CommentId { get; set; }

    public int AssignmentId { get; set; }

    public string UserId { get; set; } = null!;

    public string CommentText { get; set; } = null!;

    public bool? IsVisibleToEmployee { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual EvaluationAssignment Assignment { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
