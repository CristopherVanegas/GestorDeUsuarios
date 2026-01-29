namespace BACKEND.DTOs
{
    public class PersonaCreateDto
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public DateOnly? FechaNacimiento { get; set; }
    }

}
