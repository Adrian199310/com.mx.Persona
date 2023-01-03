using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mx.Persona.BLL.Contrac;
using com.mx.Persona.BLL.Service;
using com.mx.Persona.DAL.dalContrac;
using com.mx.Persona.DAL.dalRepository;
using Microsoft.Extensions.DependencyInjection;

namespace com.mx.Persona.IOC
{
    public static class Dependencias
    {
        public static IServiceCollection AddRegistration(this IServiceCollection service)
        {
            AddRegisterRepositories(service);
            AddRegisterServices(service);
            return service;
        }

        private static IServiceCollection AddRegisterServices(IServiceCollection service)
        {
            service.AddTransient<IPersonaService, PersonaService>();
            return service;
        }
        private static IServiceCollection AddRegisterRepositories(IServiceCollection service)
        {
            service.AddTransient<IPersonaRepository, PersonaRepository>();
            
            return service;
        }
    }
}
