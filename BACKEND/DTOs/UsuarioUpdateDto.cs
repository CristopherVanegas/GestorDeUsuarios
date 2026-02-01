namespace BACKEND.DTOs
{
    public class UsuarioUpdateDto
    {
        public string? UserName { get; set; }
        public string? Passcode { get; set; }
        public string? Mail { get; set; }
        public string? SessionActive { get; set; }
    }
}
