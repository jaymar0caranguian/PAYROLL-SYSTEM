using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.DataDB;

public partial class Attd
{
    public int AttdId { get; set; }

    public DateTime Date { get; set; }

    public int EmpId { get; set; }

    public string Holiday { get; set; }

    [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
    public TimeSpan St { get; set; }

    [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
    public TimeSpan Tr { get; set; }

    public int nd { get; set; }

    public virtual EmpInfo? EmpInfo { get; set; }
}
