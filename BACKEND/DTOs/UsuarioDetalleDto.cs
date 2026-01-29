namespace BACKEND.DTOs
{
    public class UsuarioDetalleDto
    {
        public int IdUsuario { get; set; }
        public string UserName { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string SessionActive { get; set; } = null!;
        public string Status { get; set; } = null!;

        public int PersonaId { get; set; }
        public string PersonaNombre { get; set; } = null!;
        public string PersonaApellido { get; set; } = null!;
    }
}
