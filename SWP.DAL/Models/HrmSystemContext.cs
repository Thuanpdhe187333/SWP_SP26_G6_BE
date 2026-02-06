using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace SWP.DAL.Models;

public partial class HrmSystemContext : DbContext
{
    public HrmSystemContext()
    {
    }

    public HrmSystemContext(DbContextOptions<HrmSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<AttendanceLog> AttendanceLogs { get; set; }

    public virtual DbSet<AttendanceSummary> AttendanceSummaries { get; set; }

    public virtual DbSet<BenefitAssignment> BenefitAssignments { get; set; }

    public virtual DbSet<DailyTimesheet> DailyTimesheets { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<EmploymentContract> EmploymentContracts { get; set; }

    public virtual DbSet<EvaluationAssignment> EvaluationAssignments { get; set; }

    public virtual DbSet<EvaluationComment> EvaluationComments { get; set; }

    public virtual DbSet<EvaluationConfiguration> EvaluationConfigurations { get; set; }

    public virtual DbSet<EvaluationCriterion> EvaluationCriteria { get; set; }

    public virtual DbSet<EvaluationDetail> EvaluationDetails { get; set; }

    public virtual DbSet<EvaluationHistory> EvaluationHistories { get; set; }

    public virtual DbSet<EvaluationPeriod> EvaluationPeriods { get; set; }

    public virtual DbSet<EvaluationResult> EvaluationResults { get; set; }

    public virtual DbSet<Interview> Interviews { get; set; }

    public virtual DbSet<InterviewPanel> InterviewPanels { get; set; }

    public virtual DbSet<JobPosting> JobPostings { get; set; }

    public virtual DbSet<KpiEvaluation> KpiEvaluations { get; set; }

    public virtual DbSet<LeaveBalance> LeaveBalances { get; set; }

    public virtual DbSet<LeaveRequest> LeaveRequests { get; set; }

    public virtual DbSet<LeaveType> LeaveTypes { get; set; }

    public virtual DbSet<Payroll> Payrolls { get; set; }

    public virtual DbSet<PayrollItem> PayrollItems { get; set; }

    public virtual DbSet<PayrollPeriod> PayrollPeriods { get; set; }

    public virtual DbSet<Payslip> Payslips { get; set; }

    public virtual DbSet<RecruitmentRequest> RecruitmentRequests { get; set; }

    public virtual DbSet<RefShift> RefShifts { get; set; }

    public virtual DbSet<SalaryPolicy> SalaryPolicies { get; set; }

    public virtual DbSet<ScreeningDetail> ScreeningDetails { get; set; }

    public virtual DbSet<ShiftRequest> ShiftRequests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WorkSchedule> WorkSchedules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("value"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Applicat__3213E83FF5A0C5F9");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.AppliedAt)
                .HasColumnType("datetime")
                .HasColumnName("applied_at");
            entity.Property(e => e.CvFileUrl)
                .HasMaxLength(500)
                .HasColumnName("cv_file_url");
            entity.Property(e => e.JobId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("job_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TotalScore).HasColumnName("total_score");

            entity.HasOne(d => d.Job).WithMany(p => p.Applications)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_Applications_Job");
        });

        modelBuilder.Entity<AttendanceLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__Attendan__5E5499A84326BC78");

            entity.ToTable("Attendance_Logs");

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.CheckTime).HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.AttendanceLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AttendanceLogs_Users");
        });

        modelBuilder.Entity<AttendanceSummary>(entity =>
        {
            entity.HasKey(e => e.SummaryId).HasName("PK__Attendan__DAB10E0F22702364");

            entity.ToTable("Attendance_Summaries");

            entity.Property(e => e.SummaryId).HasColumnName("SummaryID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.PeriodId).HasColumnName("PeriodID");
            entity.Property(e => e.TotalOthours)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("TotalOTHours");
            entity.Property(e => e.TotalWorkingHours).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.Period).WithMany(p => p.AttendanceSummaries)
                .HasForeignKey(d => d.PeriodId)
                .HasConstraintName("FK_AttendanceSummaries_PayrollPeriods");

            entity.HasOne(d => d.User).WithMany(p => p.AttendanceSummaries)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AttendanceSummaries_Users");
        });

        modelBuilder.Entity<BenefitAssignment>(entity =>
        {
            entity.HasKey(e => e.BenefitAssignmentId).HasName("PK__Benefit___93FACA38E08F6E7A");

            entity.ToTable("Benefit_Assignments");

            entity.Property(e => e.BenefitAssignmentId).HasColumnName("BenefitAssignmentID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BenefitName).HasMaxLength(100);
            entity.Property(e => e.BenefitType).HasMaxLength(50);
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.BenefitAssignments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Benefit_Users");
        });

        modelBuilder.Entity<DailyTimesheet>(entity =>
        {
            entity.HasKey(e => e.TimesheetId).HasName("PK__Daily_Ti__848CBECD2C32DA0B");

            entity.ToTable("Daily_Timesheets");

            entity.Property(e => e.TimesheetId).HasColumnName("TimesheetID");
            entity.Property(e => e.ActualOthours)
                .HasDefaultValue(0.0)
                .HasColumnName("ActualOTHours");
            entity.Property(e => e.EarlyLeaveMinutes).HasDefaultValue(0);
            entity.Property(e => e.LateMinutes).HasDefaultValue(0);
            entity.Property(e => e.RealCheckIn).HasColumnType("datetime");
            entity.Property(e => e.RealCheckOut).HasColumnType("datetime");
            entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Scheduled");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UserID");
            entity.Property(e => e.WorkingHours).HasDefaultValue(0.0);

            entity.HasOne(d => d.Schedule).WithMany(p => p.DailyTimesheets)
                .HasForeignKey(d => d.ScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DailyTimesheets_WorkSchedules");

            entity.HasOne(d => d.User).WithMany(p => p.DailyTimesheets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DailyTimesheets_Users");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCDDCE239A5");

            entity.Property(e => e.DepartmentId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName).HasMaxLength(100);
            entity.Property(e => e.ManagerId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ManagerID");

            entity.HasOne(d => d.Manager).WithMany(p => p.Departments)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_Departments_Manager");
        });

        modelBuilder.Entity<EmploymentContract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("PK__Employme__C90D3409E0173239");

            entity.ToTable("Employment_Contracts");

            entity.Property(e => e.ContractId).HasColumnName("ContractID");
            entity.Property(e => e.ContractStatus).HasMaxLength(50);
            entity.Property(e => e.ContractType).HasMaxLength(50);
            entity.Property(e => e.SalaryRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SalaryType).HasMaxLength(50);
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.EmploymentContracts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Contracts_Users");
        });

        modelBuilder.Entity<EvaluationAssignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__Evaluati__32499E57EDE8568A");

            entity.ToTable("Evaluation_Assignments");

            entity.HasIndex(e => new { e.PeriodId, e.ManagerId, e.EmployeeId }, "UQ_EvalAssignment_UniqueEval").IsUnique();

            entity.Property(e => e.AssignmentId).HasColumnName("AssignmentID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EmployeeID");
            entity.Property(e => e.ManagerId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ManagerID");
            entity.Property(e => e.PeriodId).HasColumnName("PeriodID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Open");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.EvaluationAssignmentEmployees)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EvalAssignments_Employee");

            entity.HasOne(d => d.Manager).WithMany(p => p.EvaluationAssignmentManagers)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EvalAssignments_Manager");

            entity.HasOne(d => d.Period).WithMany(p => p.EvaluationAssignments)
                .HasForeignKey(d => d.PeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EvalAssignments_Periods");
        });

        modelBuilder.Entity<EvaluationComment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Evaluati__C3B4DFAA0BCB3286");

            entity.ToTable("Evaluation_Comments");

            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.AssignmentId).HasColumnName("AssignmentID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsVisibleToEmployee).HasDefaultValue(true);
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.Assignment).WithMany(p => p.EvaluationComments)
                .HasForeignKey(d => d.AssignmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EvalComments_Assignments");

            entity.HasOne(d => d.User).WithMany(p => p.EvaluationComments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EvalComments_Users");
        });

        modelBuilder.Entity<EvaluationConfiguration>(entity =>
        {
            entity.HasKey(e => e.ConfigId).HasName("PK__Evaluati__C3BC333C7B56A231");

            entity.ToTable("Evaluation_Configurations");

            entity.HasIndex(e => new { e.PeriodId, e.CriteriaId }, "UQ_EvalConfig_PeriodCriteria").IsUnique();

            entity.Property(e => e.ConfigId).HasColumnName("ConfigID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CriteriaId).HasColumnName("CriteriaID");
            entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

            entity.HasOne(d => d.Criteria).WithMany(p => p.EvaluationConfigurations)
                .HasForeignKey(d => d.CriteriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EvalConfigurations_Criteria");

            entity.HasOne(d => d.Period).WithMany(p => p.EvaluationConfigurations)
                .HasForeignKey(d => d.PeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EvalConfigurations_Periods");
        });

        modelBuilder.Entity<EvaluationCriterion>(entity =>
        {
            entity.HasKey(e => e.CriteriaId).HasName("PK__Evaluati__FE6ADB2DB93AFD41");

            entity.ToTable("Evaluation_Criteria");

            entity.Property(e => e.CriteriaId).HasColumnName("CriteriaID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CriteriaName).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MaxScore).HasDefaultValue(10.0);
        });

        modelBuilder.Entity<EvaluationDetail>(entity =>
        {
            entity.HasKey(e => e.DetailId).HasName("PK__Evaluati__135C314D372D91C7");

            entity.ToTable("Evaluation_Details");

            entity.HasIndex(e => new { e.AssignmentId, e.CriteriaId }, "UQ_EvalDetail_AssignmentCriteria").IsUnique();

            entity.Property(e => e.DetailId).HasColumnName("DetailID");
            entity.Property(e => e.AssignmentId).HasColumnName("AssignmentID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CriteriaId).HasColumnName("CriteriaID");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Assignment).WithMany(p => p.EvaluationDetails)
                .HasForeignKey(d => d.AssignmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EvalDetails_Assignments");

            entity.HasOne(d => d.Criteria).WithMany(p => p.EvaluationDetails)
                .HasForeignKey(d => d.CriteriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EvalDetails_Criteria");
        });

        modelBuilder.Entity<EvaluationHistory>(entity =>
        {
            entity.HasKey(e => e.HistoryId).HasName("PK__Evaluati__4D7B4ADD00E165B0");

            entity.ToTable("Evaluation_History");

            entity.Property(e => e.HistoryId).HasColumnName("HistoryID");
            entity.Property(e => e.Action).HasMaxLength(100);
            entity.Property(e => e.AssignmentId).HasColumnName("AssignmentID");
            entity.Property(e => e.ChangedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ChangedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Assignment).WithMany(p => p.EvaluationHistories)
                .HasForeignKey(d => d.AssignmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EvalHistory_Assignments");

            entity.HasOne(d => d.ChangedByNavigation).WithMany(p => p.EvaluationHistories)
                .HasForeignKey(d => d.ChangedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EvalHistory_Users");
        });

        modelBuilder.Entity<EvaluationPeriod>(entity =>
        {
            entity.HasKey(e => e.PeriodId).HasName("PK__Evaluati__E521BB36DA4E43D8");

            entity.ToTable("Evaluation_Periods");

            entity.Property(e => e.PeriodId).HasColumnName("PeriodID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PeriodName).HasMaxLength(255);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Draft");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.EvaluationPeriods)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Evaluation_Periods_Users");
        });

        modelBuilder.Entity<EvaluationResult>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__Evaluati__976902287574590C");

            entity.ToTable("Evaluation_Results");

            entity.HasIndex(e => e.AssignmentId, "UQ__Evaluati__32499E56C6370D80").IsUnique();

            entity.Property(e => e.ResultId).HasColumnName("ResultID");
            entity.Property(e => e.AssignmentId).HasColumnName("AssignmentID");
            entity.Property(e => e.ClosedAt).HasColumnType("datetime");
            entity.Property(e => e.Conclusion).HasMaxLength(255);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SubmittedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Assignment).WithOne(p => p.EvaluationResult)
                .HasForeignKey<EvaluationResult>(d => d.AssignmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EvalResults_Assignments");
        });

        modelBuilder.Entity<Interview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Intervie__3213E83F169E1D68");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.ApplicationId)
                .HasMaxLength(50)
                .HasColumnName("application_id");
            entity.Property(e => e.FinalDecision).HasColumnName("final_decision");
            entity.Property(e => e.IsReminderSent).HasColumnName("is_reminder_sent");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            entity.Property(e => e.ScheduledAt)
                .HasColumnType("datetime")
                .HasColumnName("scheduled_at");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Application).WithMany(p => p.Interviews)
                .HasForeignKey(d => d.ApplicationId)
                .HasConstraintName("FK_Interviews_Applications");
        });

        modelBuilder.Entity<InterviewPanel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Intervie__3213E83F908DC30E");

            entity.ToTable("Interview_Panel");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.Feedback).HasColumnName("feedback");
            entity.Property(e => e.InterviewId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("interview_id");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Interview).WithMany(p => p.InterviewPanels)
                .HasForeignKey(d => d.InterviewId)
                .HasConstraintName("FK_InterviewPanel_Interviews");

            entity.HasOne(d => d.User).WithMany(p => p.InterviewPanels)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_InterviewPanel_Users");
        });

        modelBuilder.Entity<JobPosting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Job_Post__3213E83FCB5B81C2");

            entity.ToTable("Job_Postings");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.PublishedAt)
                .HasMaxLength(50)
                .HasColumnName("published_at");
            entity.Property(e => e.RequestId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("request_id");
            entity.Property(e => e.Requirements).HasColumnName("requirements");
            entity.Property(e => e.SalaryRange)
                .HasMaxLength(100)
                .HasColumnName("salary_range");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Request).WithMany(p => p.JobPostings)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK_JobPostings_Request");
        });

        modelBuilder.Entity<KpiEvaluation>(entity =>
        {
            entity.HasKey(e => e.EvaluationId).HasName("PK__KPI_Eval__36AE68D34F477873");

            entity.ToTable("KPI_Evaluations");

            entity.Property(e => e.EvaluationId).HasColumnName("EvaluationID");
            entity.Property(e => e.BonusAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.EvaluatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PeriodId).HasColumnName("PeriodID");
            entity.Property(e => e.TotalScore).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.EvaluatedByNavigation).WithMany(p => p.KpiEvaluationEvaluatedByNavigations)
                .HasForeignKey(d => d.EvaluatedBy)
                .HasConstraintName("FK_KPI_EvaluatedBy");

            entity.HasOne(d => d.Period).WithMany(p => p.KpiEvaluations)
                .HasForeignKey(d => d.PeriodId)
                .HasConstraintName("FK_KPI_Periods");

            entity.HasOne(d => d.User).WithMany(p => p.KpiEvaluationUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_KPI_Users");
        });

        modelBuilder.Entity<LeaveBalance>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LeaveTypeId, e.Year }).HasName("PK__Leave_Ba__17679933EC561E15");

            entity.ToTable("Leave_Balances");

            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UserID");
            entity.Property(e => e.LeaveTypeId).HasColumnName("LeaveTypeID");
            entity.Property(e => e.RemainingDays).HasDefaultValue(0.0);

            entity.HasOne(d => d.LeaveType).WithMany(p => p.LeaveBalances)
                .HasForeignKey(d => d.LeaveTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LeaveBalances_LeaveTypes");

            entity.HasOne(d => d.User).WithMany(p => p.LeaveBalances)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LeaveBalances_Users");
        });

        modelBuilder.Entity<LeaveRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Leave_Re__33A8519AB54E4992");

            entity.ToTable("Leave_Requests");

            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.LeaveTypeId).HasColumnName("LeaveTypeID");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.LeaveType).WithMany(p => p.LeaveRequests)
                .HasForeignKey(d => d.LeaveTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LeaveRequests_LeaveTypes");

            entity.HasOne(d => d.User).WithMany(p => p.LeaveRequests)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LeaveRequests_Users");
        });

        modelBuilder.Entity<LeaveType>(entity =>
        {
            entity.HasKey(e => e.LeaveTypeId).HasName("PK__Leave_Ty__43BE8FF4058CE4CE");

            entity.ToTable("Leave_Types");

            entity.Property(e => e.LeaveTypeId).HasColumnName("LeaveTypeID");
            entity.Property(e => e.IsPaid).HasDefaultValue(true);
            entity.Property(e => e.TypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<Payroll>(entity =>
        {
            entity.HasKey(e => e.PayrollId).HasName("PK__Payrolls__99DFC6920CD16D8D");

            entity.Property(e => e.PayrollId).HasColumnName("PayrollID");
            entity.Property(e => e.BaseSalary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BonusAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CalculatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NetSalary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Otamount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("OTAmount");
            entity.Property(e => e.PaidAt).HasColumnType("datetime");
            entity.Property(e => e.PenaltyAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PeriodId).HasColumnName("PeriodID");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.CalculatedByNavigation).WithMany(p => p.PayrollCalculatedByNavigations)
                .HasForeignKey(d => d.CalculatedBy)
                .HasConstraintName("FK_Payrolls_CalculatedBy");

            entity.HasOne(d => d.Period).WithMany(p => p.Payrolls)
                .HasForeignKey(d => d.PeriodId)
                .HasConstraintName("FK_Payrolls_Periods");

            entity.HasOne(d => d.User).WithMany(p => p.PayrollUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Payrolls_Users");
        });

        modelBuilder.Entity<PayrollItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Payroll___727E83EB34AC8DF4");

            entity.ToTable("Payroll_Items");

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ItemType).HasMaxLength(50);
            entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

            entity.HasOne(d => d.Payroll).WithMany(p => p.PayrollItems)
                .HasForeignKey(d => d.PayrollId)
                .HasConstraintName("FK_PayrollItems_Payrolls");
        });

        modelBuilder.Entity<PayrollPeriod>(entity =>
        {
            entity.HasKey(e => e.PeriodId).HasName("PK__Payroll___E521BB36E3439EE6");

            entity.ToTable("Payroll_Periods");

            entity.Property(e => e.PeriodId).HasColumnName("PeriodID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.PeriodName).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<Payslip>(entity =>
        {
            entity.HasKey(e => e.PayslipId).HasName("PK__Payslips__6EDC71423364C3B3");

            entity.Property(e => e.PayslipId).HasColumnName("PayslipID");
            entity.Property(e => e.FileUrl)
                .HasMaxLength(500)
                .HasColumnName("FileURL");
            entity.Property(e => e.GeneratedAt).HasColumnType("datetime");
            entity.Property(e => e.PayrollId).HasColumnName("PayrollID");

            entity.HasOne(d => d.Payroll).WithMany(p => p.Payslips)
                .HasForeignKey(d => d.PayrollId)
                .HasConstraintName("FK_Payslips_Payrolls");
        });

        modelBuilder.Entity<RecruitmentRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Recruitm__3213E83F2F7DD877");

            entity.ToTable("Recruitment_Requests");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.RecruitmentRequests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Recruitment_Users");
        });

        modelBuilder.Entity<RefShift>(entity =>
        {
            entity.HasKey(e => e.ShiftId).HasName("PK__Ref_Shif__C0A838E1E0F9F840");

            entity.ToTable("Ref_Shifts");

            entity.Property(e => e.ShiftId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ShiftID");
            entity.Property(e => e.IsOvernight).HasDefaultValue(false);
            entity.Property(e => e.ShiftName).HasMaxLength(100);
        });

        modelBuilder.Entity<SalaryPolicy>(entity =>
        {
            entity.HasKey(e => e.PolicyId).HasName("PK__Salary_P__2E1339440F713A2D");

            entity.ToTable("Salary_Policies");

            entity.Property(e => e.PolicyId).HasColumnName("PolicyID");
            entity.Property(e => e.BaseSalary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Otrate)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("OTRate");
            entity.Property(e => e.PenaltyRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RoleId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RoleID");
        });

        modelBuilder.Entity<ScreeningDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Screenin__3213E83F3B557A00");

            entity.ToTable("Screening_Details");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.ApplicationId)
                .HasMaxLength(50)
                .HasColumnName("application_id");
            entity.Property(e => e.CriteriaName)
                .HasMaxLength(255)
                .HasColumnName("criteria_name");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.Score).HasColumnName("score");

            entity.HasOne(d => d.Application).WithMany(p => p.ScreeningDetails)
                .HasForeignKey(d => d.ApplicationId)
                .HasConstraintName("FK_Screening_Applications");
        });

        modelBuilder.Entity<ShiftRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Shift_Re__33A8519A793D2DF5");

            entity.ToTable("Shift_Requests");

            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.ApprovedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.ShiftId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ShiftID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.ApprovedByNavigation).WithMany(p => p.ShiftRequestApprovedByNavigations)
                .HasForeignKey(d => d.ApprovedBy)
                .HasConstraintName("FK_ShiftRequests_ApprovedBy");

            entity.HasOne(d => d.Shift).WithMany(p => p.ShiftRequests)
                .HasForeignKey(d => d.ShiftId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShiftRequests_RefShifts");

            entity.HasOne(d => d.User).WithMany(p => p.ShiftRequestUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShiftRequests_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC84F7538C");

            entity.HasIndex(e => e.Email, "UQ_Users_Email").IsUnique();

            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UserID");
            entity.Property(e => e.DepartmentId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DepartmentID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Active");

            entity.HasOne(d => d.Department).WithMany(p => p.Users)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Departments");
        });

        modelBuilder.Entity<WorkSchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Work_Sch__9C8A5B69ED837A6E");

            entity.ToTable("Work_Schedules");

            entity.HasIndex(e => new { e.UserId, e.Date }, "UQ_WorkSchedule_UserDate").IsUnique();

            entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");
            entity.Property(e => e.AssignedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RequestOthours).HasColumnName("RequestOTHours");
            entity.Property(e => e.ShiftId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ShiftID");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.AssignedByNavigation).WithMany(p => p.WorkScheduleAssignedByNavigations)
                .HasForeignKey(d => d.AssignedBy)
                .HasConstraintName("FK_WorkSchedules_AssignedBy");

            entity.HasOne(d => d.Shift).WithMany(p => p.WorkSchedules)
                .HasForeignKey(d => d.ShiftId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkSchedules_RefShifts");

            entity.HasOne(d => d.User).WithMany(p => p.WorkScheduleUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkSchedules_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
