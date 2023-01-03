using com.mx.Persona.DAL.dalContrac;
using Com.mx.Persona.DOM;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace com.mx.Persona.DAL.dalRepository
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly IMemoryCache _memoryCache;
        private string key = "misPersonas";
        public PersonaRepository(IMemoryCache memoryCach)
        {
            _memoryCache = memoryCach;
        }
        public PersonaDomain Crear(PersonaDomain entidad)
        {
            
            var lista =_memoryCache.Get<List<PersonaDomain>>(key);
            if (lista != null && lista.Any())
            {
                var id_max =lista.Max(p => p.IdPersona);
                entidad.IdPersona = id_max + 1;
                lista.Add(entidad);
            }
            else
            {
                lista = new List<PersonaDomain>();
                entidad.IdPersona = 1;
                lista.Add(entidad);
            }
            _memoryCache.Set(key,lista);

            return entidad;
        }

        public bool Editar(PersonaDomain entidad)
        {
            
            var lista = _memoryCache.Get<List<PersonaDomain>>(key);
            if (lista != null && lista.Any())
            {
                var persona = lista.Where(p => p.IdPersona == entidad.IdPersona).FirstOrDefault();
                if (persona != null)
                {
                    lista.Remove(persona);
                    lista.Add(entidad);
                    _memoryCache.Remove(key);
                    _memoryCache.Set(key, lista);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public bool Eliminar(int IdPersona)
        {
            var lista = _memoryCache.Get<List<PersonaDomain>>(key);
            if (lista != null && lista.Any())
            {
                var persona = lista.Where(p => p.IdPersona == IdPersona).FirstOrDefault();
                if (persona != null)
                {
                    lista.Remove(persona);
                   
                    _memoryCache.Remove(key);
                    _memoryCache.Set(key, lista);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public PersonaDomain Obtener(int IdPersona)
        {
            var lista = _memoryCache.Get<List<PersonaDomain>>(key);
            if (lista != null && lista.Any())
            {
                var persona = lista.Where(p => p.IdPersona == IdPersona).FirstOrDefault();
                if (persona != null)
                {
                    
                    return persona;
                }
                else
                {
                    return null;
                }
            }

            return null;
        }

        public List<PersonaDomain> ObtenerLista()
        {
            var lista = _memoryCache.Get<List<PersonaDomain>>(key);
            if (lista != null && lista.Any())
            {
                var persona = lista.ToList();
                if (persona != null)
                {

                    return persona;
                }
                else
                {
                    return null;
                }
            }

            return null;
        }
    }
}
