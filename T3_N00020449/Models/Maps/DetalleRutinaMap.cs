using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T3_N00020449.Models.Maps
{
    public class DetalleRutinaMap : IEntityTypeConfiguration<DetalleRutina>
    {
        public void Configure(EntityTypeBuilder<DetalleRutina> builder)
        {
            builder.ToTable("DetalleRutina");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Ejercicios)
                .WithMany()
                .HasForeignKey(o => o.IdEjercicio);

            //builder.HasOne(o => o.Rutinas)
            //    .WithMany()
            //    .HasForeignKey(o => o.IdRutina);
        }
    }
}
