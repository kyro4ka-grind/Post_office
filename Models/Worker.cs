using System;
using System.Collections.Generic;
using Kursach_TP_Core.Models;

namespace Kursach_TP_Core;

public partial class Worker
{
    public string Login { get; set; } = null!;

    public string? Password { get; set; }

    public int Role { get; set; }

    public int? Index { get; set; }

    public virtual Department? IndexNavigation { get; set; }
}
