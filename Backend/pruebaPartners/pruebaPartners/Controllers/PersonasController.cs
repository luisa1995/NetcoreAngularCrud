using Datos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocios.Interface;
using pruebaPartners.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pruebaPartners.Controllers
{
    [Route("api/personas")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonas _personas;
        protected Response _response;
        public PersonasController(IPersonas personas)
        {
            _personas = personas;
            _response = new Response();
        }
        // GET: api/<personas>
        [HttpGet]
        public IActionResult Get()
        {
            var lista = _personas.GetPersonas();
            _response.Result = lista;
            return Ok(lista);
        }
    
        [HttpPost]
        public IActionResult Post([FromBody] Personas objpersonas)
        {
            objpersonas.FechaCreacion = DateTime.Now;
            objpersonas.NombresyApellidos = objpersonas.Nombres + ' ' + objpersonas.Apellidos;
            objpersonas.IdentificacionyNoIdentificacion = objpersonas.TipoIdentificacion + ' ' + objpersonas.NoIdentificacion;

            List<Personas> listadto = new List<Personas>();
            try
            {
                listadto = _personas.GetPersonasById(objpersonas.NoIdentificacion);

                if (listadto.Count() > 0)
                    return BadRequest("Ya existe esta persona");

                _personas.InsertPersonas(objpersonas);
                var lista = _personas.GetPersonas();
                _response.Result = lista;
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

        // PUT api/<personas>
        [HttpPut]
        public IActionResult Put([FromBody] Personas objpersonas)
        {
            objpersonas.NombresyApellidos = objpersonas.Nombres + ' ' + objpersonas.Apellidos;
            objpersonas.IdentificacionyNoIdentificacion = objpersonas.TipoIdentificacion + ' ' + objpersonas.NoIdentificacion;

            try
            {
                _personas.UpdatePersonas(objpersonas);
                var lista = _personas.GetPersonas();
                _response.Result = lista;
                _response.DisplayMessage = "Actualizado correctamente";
                return Ok(lista);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar usuario";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // DELETE api/<personas>
        [HttpDelete]
        public IActionResult Delete([FromBody] Personas objpersonas)
        {
            try
            {                
                _personas.DeletePersonas(objpersonas);
                var lista = _personas.GetPersonas();
                _response.Result = lista;
                _response.DisplayMessage = "Eliminar correctamente";
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
