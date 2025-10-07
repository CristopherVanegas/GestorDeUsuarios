using System;
using System.Collections.Generic;

namespace API_REST.Models;

public partial class RolOpcione
{
    public int IdOpcion { get; set; }

    public string NombreOpciones { get; set; } = null!;

    public string? Status { get; set; }
}
