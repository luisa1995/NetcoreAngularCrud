using pruebaPartners.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Interface
{
    public interface IPersonas
    {
        List<Personas> GetPersonas();
        List<Personas> GetPersonasById(string NoIdentificador);
        void InsertPersonas(Personas personas);
        void UpdatePersonas(Personas personas);
        void DeletePersonas(Personas personas);
    }
}
