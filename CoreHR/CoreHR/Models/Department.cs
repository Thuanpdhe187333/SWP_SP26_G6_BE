using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class Department
{
    public string DepartmentId { get; set; } = null!;

    public string DepartmentName { get; set; } = null!;

    public string? ManagerId { get; set; }

    public virtual ICollection<EvaluationAssignment> EvaluationAssignments { get; set; } = new List<EvaluationAssignment>();

    public virtual User? Manager { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
