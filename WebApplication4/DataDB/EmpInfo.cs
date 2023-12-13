using System;
using System.Collections.Generic;

namespace WebApplication4.DataDB;

public partial class EmpInfo
{
    public int EmpId { get; set; }

    public string Fname { get; set; } = null!;

    public string? Mname { get; set; }

    public string Lname { get; set; } = null!;

    public string Position { get; set; } = null!;

    public int Rate { get; set; }

    public int SssNo { get; set; }

    public int PagibigNo { get; set; }

    public int PositionId { get; set; }
    public virtual Attd Emp { get; set; } = null!;

    public virtual P EmpNavigation { get; set; } = null!;

    public virtual Position PositionNavigation { get; set; } = null!;
}
