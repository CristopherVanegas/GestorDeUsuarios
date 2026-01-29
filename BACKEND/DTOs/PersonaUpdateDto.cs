namespace BACKEND.DTOs
{
    public class PersonaUpdateDto
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public DateOnly? FechaNacimiento { get; set; }
    }
}
