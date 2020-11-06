using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T3_N00020449.Models.Maps;

namespace T3_N00020449.Models
{
    public class N00020449Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Rutina> Rutinas { get; set; }
        public DbSet<Ejercicio> Ejercicios { get; set; }
        public DbSet<DetalleRutina> DetalleRutinas { get; set; }
     
        public N00020449Context(DbContextOptions<N00020449Context> options) : base(options)
        {  }

        public N00020449Context()
        {  }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RutinaMap());
            modelBuilder.ApplyConfiguration(new EjercicioMap());
            modelBuilder.ApplyConfiguration(new DetalleRutinaMap());
        
        }
    }
}
