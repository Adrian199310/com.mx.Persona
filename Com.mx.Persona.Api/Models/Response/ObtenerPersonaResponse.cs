using Com.mx.Persona.DOM;

namespace Com.mx.Persona.Api.Models.Response
{
    public class ObtenerPersonaResponse:BaseResponse
    {
        public List<PersonaDomain> personas { get; set; }
    }
}
