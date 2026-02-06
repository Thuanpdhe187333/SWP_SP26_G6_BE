using System;
using System.Collections.Generic;

namespace SWP.DAL.Models;

public partial class Department
{
    public string DepartmentId { get; set; } = null!;

    public string DepartmentName { get; set; } = null!;

    public string? ManagerId { get; set; }

    public virtual User? Manager { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
