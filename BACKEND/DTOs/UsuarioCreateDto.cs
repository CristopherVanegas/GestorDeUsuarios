namespace BACKEND.DTOs
{
    public class UsuarioCreateDto
    {
        public string UserName { get; set; } = null!;
        public string Passcode { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public int PersonaIdPersona2 { get; set; }
    }
}
