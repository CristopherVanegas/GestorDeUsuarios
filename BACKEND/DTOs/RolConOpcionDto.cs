namespace BACKEND.DTOs
{
    public class RolConOpcionDto
    {
        public int RolId { get; set; }
        public string RolNombre { get; set; } = null!;
        public int OpcionId { get; set; }
        public string OpcionNombre { get; set; } = null!;
    }
}
