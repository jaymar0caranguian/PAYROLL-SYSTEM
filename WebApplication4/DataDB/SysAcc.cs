using System;
using System.Collections.Generic;

namespace WebApplication4.DataDB;

public partial class SysAcc
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Pass { get; set; } = null!;
}
