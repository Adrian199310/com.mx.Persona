using Com.mx.Persona.DOM;

namespace Com.mx.Persona.Api.Models.Response
{
    public class CreatePersonaResponse : BaseResponse
    {
        public PersonaDomain persona { get; set; }
    }
}
