using System;
using System.Collections.Generic;

namespace CoreHR.Models;

public partial class ScreeningDetail
{
    public string Id { get; set; } = null!;

    public string? ApplicationId { get; set; }

    public string? CriteriaName { get; set; }

    public int? Score { get; set; }

    public string? Note { get; set; }

    public virtual Application? Application { get; set; }
}
