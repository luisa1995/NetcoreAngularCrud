using Microsoft.EntityFrameworkCore;
using pruebaPartners.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Context
{
    public class UsuariosContext : DbContext
    {
        public UsuariosContext(DbContextOptions<UsuariosContext> options) : base(options)
        {
        }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
