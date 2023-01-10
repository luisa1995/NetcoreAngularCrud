using System.ComponentModel.DataAnnotations;

namespace pruebaPartners.Models
{
    public class Usuarios
    {
        [Key]
        public int Identificador { get; set; }

        public string Usuario { get; set; }
        public string Password { get; set; }
        public System.Nullable<DateTime> FechaCreacion { get; set; }
    }
}
