using Estacionamiento_D.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Estacionamiento_D.Data
{
    public class EstacionamientoDb : DbContext
    {
        public EstacionamientoDb(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

    }
}
