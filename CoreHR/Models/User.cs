using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string Role { get; set; } = null!;

    public string DepartmentId { get; set; } = null!;

    public DateOnly HireDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<AttendanceLog> AttendanceLogs { get; set; } = new List<AttendanceLog>();

    public virtual ICollection<AttendanceSummary> AttendanceSummaries { get; set; } = new List<AttendanceSummary>();

    public virtual ICollection<BenefitAssignment> BenefitAssignments { get; set; } = new List<BenefitAssignment>();

    public virtual ICollection<DailyTimesheet> DailyTimesheets { get; set; } = new List<DailyTimesheet>();

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<EmploymentContract> EmploymentContracts { get; set; } = new List<EmploymentContract>();

    public virtual ICollection<EvaluationAssignment> EvaluationAssignmentEmployees { get; set; } = new List<EvaluationAssignment>();

    public virtual ICollection<EvaluationAssignment> EvaluationAssignmentManagers { get; set; } = new List<EvaluationAssignment>();

    public virtual ICollection<InterviewPanel> InterviewPanels { get; set; } = new List<InterviewPanel>();

    public virtual ICollection<KpiEvaluation> KpiEvaluationEvaluatedByNavigations { get; set; } = new List<KpiEvaluation>();

    public virtual ICollection<KpiEvaluation> KpiEvaluationUsers { get; set; } = new List<KpiEvaluation>();

    public virtual ICollection<LeaveBalance> LeaveBalances { get; set; } = new List<LeaveBalance>();

    public virtual ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();

    public virtual ICollection<ManagerFeedback> ManagerFeedbacks { get; set; } = new List<ManagerFeedback>();

    public virtual ICollection<Payroll> PayrollCalculatedByNavigations { get; set; } = new List<Payroll>();

    public virtual ICollection<Payroll> PayrollUsers { get; set; } = new List<Payroll>();

    public virtual ICollection<RecruitmentRequest> RecruitmentRequests { get; set; } = new List<RecruitmentRequest>();

    public virtual ICollection<ShiftRequest> ShiftRequestApprovedByNavigations { get; set; } = new List<ShiftRequest>();

    public virtual ICollection<ShiftRequest> ShiftRequestUsers { get; set; } = new List<ShiftRequest>();

    public virtual ICollection<WorkSchedule> WorkScheduleAssignedByNavigations { get; set; } = new List<WorkSchedule>();

    public virtual ICollection<WorkSchedule> WorkScheduleUsers { get; set; } = new List<WorkSchedule>();
}
