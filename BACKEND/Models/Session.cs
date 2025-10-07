using System;
using System.Collections.Generic;

namespace BACKEND.Models;

public partial class Session
{
    public DateTime FechaIngreso { get; set; }

    public DateTime? FechaCierre { get; set; }

    public int UsuarioIdUsuario { get; set; }

    public string? Status { get; set; }

    public virtual Usuario UsuarioIdUsuarioNavigation { get; set; } = null!;
}
