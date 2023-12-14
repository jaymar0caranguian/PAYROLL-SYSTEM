using System;
using System.Collections.Generic;

namespace WebApplication4.DataDB;

public partial class Position
{
    public int PositionId { get; set; }

    public string? Position1 { get; set; }
    public virtual ICollection<EmpInfo> EmpInfos { get; set; } = new List<EmpInfo>();
}
