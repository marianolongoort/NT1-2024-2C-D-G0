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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //key de m:n
            modelBuilder.Entity<ClienteVehiculo>().HasKey(cv  => new { cv.ClienteId,cv.VehiculoId});

            modelBuilder.Entity<ClienteVehiculo>()
                                .HasOne(cv => cv.Cliente)
                                    .WithMany(c => c.ClientesVehiculos)
                                .HasForeignKey(cv => cv.ClienteId);

            modelBuilder.Entity<ClienteVehiculo>()
                                .HasOne(cv => cv.Vehiculo)
                                .WithMany(v => v.ClientesVehiculos)
                                .HasForeignKey(cv => cv.VehiculoId);

        }


        public DbSet<Persona> Personas { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Estacionamiento_D.Models.Direccion> Direccion { get; set; }
        public DbSet<Estacionamiento_D.Models.ClienteVehiculo> ClienteVehiculo { get; set; }
        public DbSet<Estacionamiento_D.Models.Vehiculo> Vehiculo { get; set; }

    }
}
