using Microsoft.AspNetCore.Http;

namespace Com.mx.Persona.Api.Models.Response
{
    public class BaseResponse
    {
            public bool Code { get; set; }

            public string Mensaje { get; set; }

            public string Error { get; set; }
    }
}
