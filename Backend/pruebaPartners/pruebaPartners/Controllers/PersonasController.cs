using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pruebaPartners.DataContext;
using pruebaPartners.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pruebaPartners.Controllers
{
    [Route("api/personas")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        readonly PersonasContext PersonasDetails;
        public PersonasController(PersonasContext personasContext)
        {
            PersonasDetails = personasContext;
        }
        // GET: api/<personas>
        [HttpGet]
        public IEnumerable<Personas> Get()
        {
            var data = PersonasDetails.Personas.ToList();
            return data;
        }

        // GET api/<personas>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    
        [HttpPost]
        public IActionResult Post([FromBody] Personas objpersonas)
        {
            objpersonas.FechaCreacion = DateTime.Now;
            objpersonas.NombresyApellidos = objpersonas.Nombres + ' ' + objpersonas.Apellidos;
            objpersonas.IdentificacionyNoIdentificacion = objpersonas.TipoIdentificacion + ' ' + objpersonas.NoIdentificacion;
           
            PersonasDetails.Personas.Add(objpersonas);
            PersonasDetails.SaveChanges();
            return Ok();
        }

        // PUT api/<personas>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Personas objpersonas)
        {
            objpersonas.NombresyApellidos = objpersonas.Nombres + ' ' + objpersonas.Apellidos;
            objpersonas.IdentificacionyNoIdentificacion = objpersonas.TipoIdentificacion + ' ' + objpersonas.NoIdentificacion;

            PersonasDetails.Personas.Update(objpersonas);
            PersonasDetails.SaveChanges();
            return Ok();
        }

        // DELETE api/<personas>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = PersonasDetails.Personas.Where(a => a.Identificador == id).FirstOrDefault();
            PersonasDetails.Personas.Remove(data);
            PersonasDetails.SaveChanges();
            return Ok();
        }
    }
}
