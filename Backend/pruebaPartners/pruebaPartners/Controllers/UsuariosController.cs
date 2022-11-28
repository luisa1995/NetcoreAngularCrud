using Microsoft.AspNetCore.Mvc;
using pruebaPartners.DataContext;
using pruebaPartners.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pruebaPartners.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        readonly UsuariosContext UsuarDetails;
        public UsuariosController(UsuariosContext usuariosContext)
        {
            UsuarDetails = usuariosContext;
        }


        // GET: api/<UsuariosController>
        [HttpGet]
        public IEnumerable<Usuarios> Get()
        {
            var data = UsuarDetails.Usuarios.ToList();
            return data;
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public IActionResult Post([FromBody] Usuarios objUsuario)
        {
            objUsuario.FechaCreacion = DateTime.Now;
            UsuarDetails.Usuarios.Add(objUsuario);
            UsuarDetails.SaveChanges();
            return Ok();
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuarios objUsuario)
        {
            UsuarDetails.Usuarios.Update(objUsuario);
            UsuarDetails.SaveChanges();
            return Ok();
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = UsuarDetails.Usuarios.Where(a => a.Identificador == id).FirstOrDefault();
            UsuarDetails.Usuarios.Remove(data);
            UsuarDetails.SaveChanges();
            return Ok();

        }
    }
}
