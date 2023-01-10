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
    public class UsuariosRepo : IUsuarios
    {
        private readonly UsuariosDao _service;
        public UsuariosRepo(IConfiguration configuration)
        {
            _service = new UsuariosDao(configuration);
        }
        public void DeleteUsuarios(Usuarios usuarios)
        {
            _service.DeleteUsuarios(usuarios);
        }
        public List<Usuarios> GetUsuarios()
        {        
            return _service.GetUsuarios();
        }
        public List<Usuarios> GetUsuariosById(string Usuario)
        {
            return _service.GetUsuariosById(Usuario);
        }
        public void InsertUsuarios(Usuarios usuarios)
        {
            _service.InsertUsuarios(usuarios);
        }
        public void UpdateUsuarios(Usuarios usuarios)
        {
            _service.UpdateUsuarios(usuarios);
        }
    }
}
