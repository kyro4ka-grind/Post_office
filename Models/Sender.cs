using System;
using System.Collections.Generic;

namespace Kursach_TP_Core;

public partial class Sender
{
    public string? Name { get; set; }

    public string? Surname { get; set; }

    public long PassportNum { get; set; }

    public long? PhoneNum { get; set; }

    public virtual ICollection<Package> Packages { get; } = new List<Package>();
}
