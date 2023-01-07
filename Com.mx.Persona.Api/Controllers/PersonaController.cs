using com.mx.Persona.BLL.Contrac;
using Com.mx.Persona.Api.Models.Request;
using Com.mx.Persona.Api.Models.Response;
using Com.mx.Persona.DOM;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Com.mx.Persona.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;

        public PersonaController(IPersonaService personaService)
        {
            _personaService= personaService;
        }

        // GET: api/<PersonaController>
        //[HttpGet("GetPersona")]
        [HttpGet("")]
        public ActionResult<ObtenerPersonaResponse> Get()
        {
            var response = new ObtenerPersonaResponse();
            try
            {
                
                var personas = _personaService.GetListPersonas();
                if (personas != null && personas.Any())
                {
                    response.personas = personas;
                    response.Code = true;

                    return Ok(response);
                }
                else
                {
                    response.personas = null;
                    response.Code = false;
                    response.Mensaje = "No existen datos de persona";

                    return StatusCode(404, response);
                }
            }
            catch (Exception ex)
            {
                response.personas = null;
                response.Code = false;
                response.Mensaje = ex.Message;
                return StatusCode(500, response);
            }
            
            
            
        }

        // GET api/<PersonaController>/5
        //[HttpGet("GetPersona/{id}")]
        [HttpGet("{id}")]
        public ActionResult<ObtenerPersonaResponse> Get(int id)
        {
            var response = new ObtenerPersonaResponse();
            try
            {
                var listresponse = new List<PersonaDomain>();
                var personas = _personaService.getPersona(id);
                if (personas != null)
                {
                    listresponse.Add(personas);
                    response.personas = listresponse;
                    response.Code = true;

                    return Ok(response);
                }
                else
                {
                    response.personas = null;
                    response.Code = false;
                    response.Mensaje = "No existen datos de persona";

                    return StatusCode(404, response);
                }
            }
            catch (Exception ex)
            {
                response.personas = null;
                response.Code = false;
                response.Mensaje = ex.Message;
                return StatusCode(500, response);
            }



        }

        // POST api/<PersonaController>
        [HttpPost]
        public ActionResult<CreatePersonaResponse> Post([FromBody] CreatePersonaRequest value)
        {
            var response = new CreatePersonaResponse();
            try
            {
                PersonaDomain personaDomain = MapearClase(value);
               var resposeDomein = _personaService.CreatePersona(personaDomain);

                if (resposeDomein != null)
                {
                    response.persona = resposeDomein;
                    response.Code = true;
                    
                    return Ok(response);
                }
                else
                {
                    response.persona = null;
                    response.Code = false;
                    response.Mensaje = "No existen datos de persona";

                    return StatusCode(404, response);
                }

            }
            catch (Exception ex)
            {
                response.persona = null;
                response.Code = false;
                response.Mensaje = ex.Message;
                return StatusCode(500, response);
            }
        }

        private PersonaDomain MapearClase(CreatePersonaRequest value)
        {
            var persona = new PersonaDomain();
            persona.Nombre= value.Nombre;
            persona.IdPersona = value.IdPersona;
            persona.ApellidoPaterno= value.ApellidoPaterno;
            persona.ApellidoMaterno= value.ApellidoMaterno;
            persona.Telefono= value.Telefono;
            persona.Email= value.Email;

            return persona;
        }
        private PersonaDomain MapearClase(updatePersonaRequest value)
        {
            var persona = new PersonaDomain();
            persona.Nombre = value.Nombre;
            persona.IdPersona = value.IdPersona;
            persona.ApellidoPaterno = value.ApellidoPaterno;
            persona.ApellidoMaterno = value.ApellidoMaterno;
            persona.Telefono = value.Telefono;
            persona.Email = value.Email;

            return persona;
        }

        // PUT api/<PersonaController>/5
        [HttpPut]
        public ActionResult<UpdatePersonaResponse> Put([FromBody] updatePersonaRequest value)
        {
            var response = new UpdatePersonaResponse();
            try
            {
                PersonaDomain personaDomain = MapearClase(value);
                var resposeDomein = _personaService.UpdatePersona(personaDomain);

                if (resposeDomein != null)
                {
                    response.persona = resposeDomein;
                    response.Code = true;

                    return Ok(response);
                }
                else
                {
                    response.persona = null;
                    response.Code = false;
                    response.Mensaje = "No existen datos de persona";

                    return StatusCode(404, response);
                }

            }
            catch (Exception ex)
            {
                response.persona = null;
                response.Code = false;
                response.Mensaje = ex.Message;
                return StatusCode(500, response);
            }
        }

        // DELETE api/<PersonaController>/5
        [HttpDelete("{id}")]
        public ActionResult<DeletePersonaResponse> Delete(int id)
        {
            var response = new DeletePersonaResponse();
            try
            {
                var personas = _personaService.DeletePersona(id);
                if (personas)
                {
                    response.Code = true;
                    return Ok(response);
                }
                else
                {
                    response.Code = false;
                    response.Mensaje = "No existen datos de persona";

                    return StatusCode(404, response);
                }
            }
            catch (Exception ex)
            {
                response.Code = false;
                response.Mensaje = ex.Message;
                return StatusCode(500, response);
            }
        }
    }
}
