using Com.mx.Persona.DOM;

namespace Com.mx.Persona.Api.Models.Response
{
    public class UpdatePersonaResponse: BaseResponse
    {
        public PersonaDomain persona { get; set; }
    }
}
