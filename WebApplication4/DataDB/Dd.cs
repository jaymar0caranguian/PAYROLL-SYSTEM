using System;
using System.Collections.Generic;

namespace WebApplication4.DataDB;

public partial class Dd
{
    public int DdId { get; set; }

    public string Ddname { get; set; } = null!;

    public int Percentage { get; set; }

    //public virtual ICollection<EmpInfo> EmpInfos { get; set; } = new List<EmpInfo>();
}
