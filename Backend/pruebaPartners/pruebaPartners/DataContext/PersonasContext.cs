using Microsoft.EntityFrameworkCore;
using pruebaPartners.Models;

namespace pruebaPartners.DataContext
{
    public class PersonasContext : DbContext
    {
        public PersonasContext(DbContextOptions<PersonasContext> options) : base(options)
        {
        } 
        public DbSet<Personas> Personas { get; set; }
    }
}
