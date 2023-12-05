using System;
using System.Collections.Generic;

namespace WebApplication4.DataDB;

public partial class Attd
{
    public int AttdId { get; set; }

    public DateTime Date { get; set; }

    public int EmpId { get; set; }

    public int Holiday { get; set; }

    public int St { get; set; }

    public int Tr { get; set; }

    public int Nd { get; set; }

    public virtual EmpInfo? EmpInfo { get; set; }
}
