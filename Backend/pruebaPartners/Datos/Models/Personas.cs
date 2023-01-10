using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace pruebaPartners.Models
{
    public class Personas
    {
        [Key]
        public int Identificador { get; set; }

        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NoIdentificacion { get; set; }
        public string? Email { get; set; }
        public string TipoIdentificacion {get;set;}
        public System.Nullable<DateTime> FechaCreacion { get; set; }
        public string? NombresyApellidos { get; set; }
        public string? IdentificacionyNoIdentificacion { get; set; }
    }

}
