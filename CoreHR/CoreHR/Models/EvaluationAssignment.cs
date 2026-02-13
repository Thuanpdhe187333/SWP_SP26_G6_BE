using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class EvaluationAssignment
{
    public int AssignmentId { get; set; }

    public int? PeriodId { get; set; }

    public string? EmployeeId { get; set; }

    public string? ManagerId { get; set; }

    public string? DepartmentId { get; set; }

    public DateOnly? DueDate { get; set; }

    public string? Status { get; set; }

    public virtual Department? Department { get; set; }

    public virtual User? Employee { get; set; }

    public virtual User? Manager { get; set; }

    public virtual PayrollPeriod? Period { get; set; }
}
