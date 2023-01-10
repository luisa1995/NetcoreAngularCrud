using Datos.Models;
using Microsoft.AspNetCore.Mvc;
using Negocios.Interface;
using pruebaPartners.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pruebaPartners.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarios _usuarios;
        protected Response _response;

        public UsuariosController(IUsuarios usuarios)
        {
            _usuarios = usuarios;
            _response = new Response();
        }

        // GET: api/<UsuariosController>
        [HttpGet]
        public IActionResult Get()
        {
            var lista = _usuarios.GetUsuarios();
            return Ok(lista);
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public IActionResult Post([FromBody] Usuarios objUsuario)
        {
            objUsuario.FechaCreacion = DateTime.Now;
            List<Usuarios> listadto = new List<Usuarios>();

            try
            {
                listadto = _usuarios.GetUsuariosById(objUsuario.Usuario);

                if (listadto.Count() > 0)
                    return BadRequest("Ya existe este usuario");

                _usuarios.InsertUsuarios(objUsuario);
                var lista = _usuarios.GetUsuarios();
                _response.DisplayMessage = "Guardado correctamente";
                return Ok(lista);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al guardar usuario";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }            
        }

        // PUT api/<UsuariosController>
        [HttpPut]
        public IActionResult Put([FromBody] Usuarios objUsuario)
        {
            objUsuario.FechaCreacion = DateTime.Now;
            List<Usuarios> listadto = new List<Usuarios>();

            try
            {
                listadto = _usuarios.GetUsuariosById(objUsuario.Usuario);

                if (listadto.Count() > 0 && listadto[0].Identificador != objUsuario.Identificador)
                {
                    return BadRequest("Ya existe este usuario");
                }
                else
                {
                    _usuarios.UpdateUsuarios(objUsuario);
                    var lista = _usuarios.GetUsuarios();
                    _response.DisplayMessage = "Actualizado correctamente";
                    return Ok(lista);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar usuario";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // DELETE api/<UsuariosController>
        [HttpDelete]
        public IActionResult Delete([FromBody] Usuarios objUsuario)
        {
            try
            {              
                _usuarios.DeleteUsuarios(objUsuario);
                var lista = _usuarios.GetUsuarios();
                _response.DisplayMessage = "Eliminado correctamente";
                return Ok(lista);
                
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al eliminar usuario";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }

        }
    }
}
