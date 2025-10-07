using System;
using System.Collections.Generic;

namespace API_REST.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string UserName { get; set; } = null!;

    public string Passcode { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string? SessionActive { get; set; }

    public int PersonaIdPersona2 { get; set; }

    public string? Status { get; set; }

    public virtual Persona PersonaIdPersona2Navigation { get; set; } = null!;
}
