using System.ComponentModel.DataAnnotations;

namespace Com.mx.Persona.Api.Models.Request
{
    public class updatePersonaRequest
    {
        [Required]
        public int IdPersona { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
