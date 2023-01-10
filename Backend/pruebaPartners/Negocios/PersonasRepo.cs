using Datos;
using Microsoft.Extensions.Configuration;
using Negocios.Interface;
using pruebaPartners.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class PersonasRepo : IPersonas
    {
        private readonly PersonasDao _service;
        public PersonasRepo(IConfiguration configuration)
        {
            _service = new PersonasDao(configuration);
        }
        public void DeletePersonas(Personas personas)
        {
            _service.DeletePersonas(personas);
        }

        public List<Personas> GetPersonas()
        {
            return _service.GetPersonas();
        }

        public List<Personas> GetPersonasById(string NoIdentificador)
        {
            return _service.GetPersonasById(NoIdentificador);
        }

        public void InsertPersonas(Personas personas)
        {
            _service.InsertPersonas(personas);
        }

        public void UpdatePersonas(Personas personas)
        {
            _service.UpdatePersonas(personas);
        }
    }
}
