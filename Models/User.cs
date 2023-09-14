using System;
using System.Collections.Generic;

namespace Kursach_TP_Core;

public partial class User
{
    public string Login { get; set; } = null!;

    public string? Password { get; set; }

    public string? Mail { get; set; }
}
