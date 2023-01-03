using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.mx.Persona.DOM;


namespace com.mx.Persona.BLL.Contrac
{
    public interface IPersonaService
    {
        List<PersonaDomain> GetListPersonas();
        PersonaDomain getPersona(int idPersona);
        PersonaDomain CreatePersona(PersonaDomain persona);
        PersonaDomain UpdatePersona(PersonaDomain persona);
        bool DeletePersona(int idPersona);

    }
}
