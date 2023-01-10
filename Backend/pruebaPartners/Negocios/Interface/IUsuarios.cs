using pruebaPartners.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Interface
{
    public interface IUsuarios
    {
        List<Usuarios> GetUsuarios();
        List<Usuarios> GetUsuariosById(string cedula);
        void InsertUsuarios(Usuarios usuarios);
        void UpdateUsuarios(Usuarios usuarios);
        void DeleteUsuarios(Usuarios usuarios);
    }
}
