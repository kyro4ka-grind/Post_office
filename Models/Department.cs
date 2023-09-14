using System;
using System.Collections.Generic;

namespace Kursach_TP_Core.Models;

public partial class Department
{
    public int Index { get; set; }

    public int? Operators { get; set; }

    public int? Postmans { get; set; }

    public int? Workers { get; set; }

    public bool IsOpen { get; set; }

    public int? IdPlace { get; set; }

    public virtual Place? IdPlaceNavigation { get; set; }

    public virtual ICollection<Worker> WorkersNavigation { get; } = new List<Worker>();
}
