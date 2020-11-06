using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T3_N00020449.Models.Maps
{
    public class RutinaMap : IEntityTypeConfiguration<Rutina>
    {
        public void Configure(EntityTypeBuilder<Rutina> builder)
        {
            builder.ToTable("Rutina");
            builder.HasKey(o => o.Id);

            
            

            //builder.HasOne(o => o.Users)
            //    .WithMany()
            //    .HasForeignKey(o => o.IdUsuario);

            //builder.HasMany(o => o.DetalleRutinas)
            //    .WithOne()
            //    .HasForeignKey(o => o.IdRutina);

        }
    }
}
