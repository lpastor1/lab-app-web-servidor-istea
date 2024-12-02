using lab_app_web_servidor_istea.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lab_app_web_servidor_istea.Database.DataSeed;

public class MesaSeed : IEntityTypeConfiguration<Mesa>
{
  public void Configure(EntityTypeBuilder<Mesa> builder)
  {
    builder.HasData(
        new Mesa() { Id = 1, Nombre = "Mesa101", EstadosMesaId = 3 },
        new Mesa() { Id = 2, Nombre = "Mesa102", EstadosMesaId = 3 },
        new Mesa() { Id = 4, Nombre = "Mesa103", EstadosMesaId = 3 },
        new Mesa() { Id = 3, Nombre = "Mesa104", EstadosMesaId = 3 },
        new Mesa() { Id = 5, Nombre = "Mesa201", EstadosMesaId = 3 },
        new Mesa() { Id = 6, Nombre = "Mesa202", EstadosMesaId = 3 },
        new Mesa() { Id = 7, Nombre = "Mesa203", EstadosMesaId = 3 },
        new Mesa() { Id = 8, Nombre = "Mesa204", EstadosMesaId = 3 }
    );
  }
}