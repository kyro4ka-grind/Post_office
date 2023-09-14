using System;
using System.Collections.Generic;
using Kursach_TP_Core.Models;

namespace Kursach_TP_Core;

public partial class Place
{
    public int Id { get; set; }

    public string? Country { get; set; }

    public string? Town { get; set; }

    public int? Index { get; set; }

    public virtual ICollection<Department> Departments { get; } = new List<Department>();

    public virtual ICollection<Package> PackageIdPlaceInNavigations { get; } = new List<Package>();

    public virtual ICollection<Package> PackageIdPlaceOutNavigations { get; } = new List<Package>();
}
