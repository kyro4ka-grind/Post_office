using System;
using System.Collections.Generic;

namespace Kursach_TP_Core;

public partial class Package
{
    public string IdPack { get; set; } = null!;

    public int? IdPlaceOut { get; set; }

    public int? IdPlaceIn { get; set; }

    public long? Sender { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public int Status { get; set; }

    public virtual Place? IdPlaceInNavigation { get; set; }

    public virtual Place? IdPlaceOutNavigation { get; set; }

    public virtual Sender? SenderNavigation { get; set; }
}
