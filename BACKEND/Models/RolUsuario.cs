using System;
using System.Collections.Generic;

namespace API_REST.Models;

public partial class RolUsuario
{
    public int RolIdRol { get; set; }

    public int UsuarioIdUsuario { get; set; }

    public virtual Rol RolIdRolNavigation { get; set; } = null!;

    public virtual Usuario UsuarioIdUsuarioNavigation { get; set; } = null!;
}
