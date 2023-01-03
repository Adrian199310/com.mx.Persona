using Com.mx.Persona.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace com.mx.Persona.DAL.dalContrac
{
    public interface IPersonaRepository
    {
        PersonaDomain Obtener(int IdPersona);
        PersonaDomain Crear(PersonaDomain entidad);
        bool Editar(PersonaDomain entidad);
        bool Eliminar(int IdPersona);
        List<PersonaDomain> ObtenerLista();
    }
}
