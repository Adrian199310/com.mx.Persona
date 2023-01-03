using com.mx.Persona.BLL.Contrac;
using com.mx.Persona.DAL.dalContrac;
using Com.mx.Persona.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mx.Persona.BLL.Service
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _repository;

        public PersonaService(IPersonaRepository repository)
        {
            this._repository = repository;
        }

        public PersonaDomain CreatePersona(PersonaDomain persona)
        {
            try
            {
               PersonaDomain persona_creada =  _repository.Crear(persona);
                if (persona_creada.IdPersona == 0)
                    throw new TaskCanceledException("No se pudo crear a la persona");

                return persona_creada;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public  bool DeletePersona(int idPersona)
        {
            PersonaDomain persona_consultada =  _repository.Obtener(idPersona);
            if (persona_consultada == null || persona_consultada.IdPersona < 1)
                throw new TaskCanceledException("No se pudo encontrar a las persona");

            return  _repository.Eliminar(persona_consultada.IdPersona);
        }

        public  List<PersonaDomain> GetListPersonas()
        {
           return  _repository.ObtenerLista();
        }

        public  PersonaDomain getPersona(int idPersona)
        {
            PersonaDomain persona_consultada =  _repository.Obtener(idPersona);
            if (persona_consultada == null || persona_consultada.IdPersona < 1)
                throw new TaskCanceledException("No se pudo encontrar a la persona");

            return persona_consultada;
        }

        public  PersonaDomain UpdatePersona(PersonaDomain persona)
        {
            PersonaDomain persona_consultada =  _repository.Obtener(persona.IdPersona);
            if (persona_consultada == null || persona_consultada.IdPersona < 1)
                throw new TaskCanceledException("No se pudo encontrar a la persona");

            persona_consultada.Nombre = persona.Nombre;
            persona_consultada.ApellidoPaterno = persona.ApellidoPaterno;
            persona_consultada.ApellidoMaterno = persona.ApellidoMaterno;
            persona_consultada.Telefono = persona.Telefono;
            persona_consultada.Email = persona.Email;

            var res =  _repository.Editar(persona_consultada);
            if (!res)
                throw new TaskCanceledException("No se pudo actualizar a la persona");

            return persona_consultada;
        }

    }
}
