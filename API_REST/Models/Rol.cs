using System;
using System.Collections.Generic;

namespace API_REST.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string RolName { get; set; } = null!;

    public string? Status { get; set; }
}
