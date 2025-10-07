using System;
using System.Collections.Generic;

namespace API_REST.Models;

public partial class RolRolOpcione
{
    public int RolIdRol { get; set; }

    public int RolOpcionesIdOpciones { get; set; }

    public virtual Rol RolIdRolNavigation { get; set; } = null!;

    public virtual RolOpcione RolOpcionesIdOpcionesNavigation { get; set; } = null!;
}
