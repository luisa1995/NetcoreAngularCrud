using Microsoft.EntityFrameworkCore;
using pruebaPartners.Models;

namespace pruebaPartners.DataContext
{
    public class UsuariosContext: DbContext
    {
        public UsuariosContext(DbContextOptions<UsuariosContext> options) : base(options)
        {
        }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
