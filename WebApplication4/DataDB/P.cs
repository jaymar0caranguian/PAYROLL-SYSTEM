using System;
using System.Collections.Generic;

namespace WebApplication4.DataDB;

public partial class P
{
    public int PsId { get; set; }

    public int EmpId { get; set; }

    public int AttdId { get; set; }

    public int DdId { get; set; }

    public virtual EmpInfo? EmpInfo { get; set; }
}
