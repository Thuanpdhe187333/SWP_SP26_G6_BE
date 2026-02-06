using Microsoft.Extensions.DependencyInjection;
using SWP.DAL.Models;

public static class DbSeeder
{
    public static void Seed(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<HrmSystemContext>();

        // Không seed lại
        if (context.Users.Any())
            return;

        // ===============================
        // 1. DEPARTMENTS
        // ===============================
        var hrDepartment = new Department
        {
            DepartmentId = "HR",
            DepartmentName = "Human Resources"
        };

        var itDepartment = new Department
        {
            DepartmentId = "IT",
            DepartmentName = "IT Department"
        };

        context.Departments.AddRange(hrDepartment, itDepartment);
        context.SaveChanges();

        // ===============================
        // 2. HR 
        // ===============================
        var hr = new User
        {
            UserId = "HR01",
            Email = "hr@gmail.com",
            FullName = "HR Admin",
            Role = "HR",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
            DepartmentId = "HR",          
            Status = "Active",
            HireDate = DateOnly.FromDateTime(DateTime.Now),
            DateOfBirth = new DateOnly(1990, 1, 1)
        };

        // ===============================
        // 3. DEPARTMENT MANAGER
        // ===============================
        var manager = new User
        {
            UserId = "MGR01",
            Email = "manager@gmail.com",
            FullName = "IT Manager",
            Role = "DepartmentManager",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
            DepartmentId = "IT",
            Status = "Active",
            HireDate = DateOnly.FromDateTime(DateTime.Now),
            DateOfBirth = new DateOnly(1985, 5, 5)
        };

        context.Users.AddRange(hr, manager);
        context.SaveChanges();

        // Gán manager cho phòng IT
        itDepartment.ManagerId = manager.UserId;
        context.SaveChanges();

        // ===============================
        // 4. EMPLOYEES (ACTIVE)
        // ===============================
        var emp1 = new User
        {
            UserId = "EMP01",
            Email = "emp1@gmail.com",
            FullName = "Employee One",
            Role = "Employee",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
            DepartmentId = "IT",
            Status = "Active",
            HireDate = DateOnly.FromDateTime(DateTime.Now),
            DateOfBirth = new DateOnly(2000, 3, 3)
        };

        var emp2 = new User
        {
            UserId = "EMP02",
            Email = "emp2@gmail.com",
            FullName = "Employee Two",
            Role = "Employee",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
            DepartmentId = "IT",
            Status = "Active",
            HireDate = DateOnly.FromDateTime(DateTime.Now),
            DateOfBirth = new DateOnly(2001, 4, 4)
        };

        // ===============================
        // 5. EMPLOYEE INACTIVE (TEST LOGIN)
        // ===============================
        var inactiveEmployee = new User
        {
            UserId = "EMP99",
            Email = "inactive@gmail.com",
            FullName = "Inactive Employee",
            Role = "Employee",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
            DepartmentId = "IT",
            Status = "Inactive",          // chưa active
            HireDate = DateOnly.FromDateTime(DateTime.Now),
            DateOfBirth = new DateOnly(2002, 6, 6)
        };

        context.Users.AddRange(emp1, emp2, inactiveEmployee);
        context.SaveChanges();
    }
}
