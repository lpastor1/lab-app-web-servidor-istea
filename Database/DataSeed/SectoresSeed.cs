using lab_app_web_servidor_istea.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lab_app_web_servidor_istea.Database.DataSeed;

public class SectoresSeed : IEntityTypeConfiguration<Sector>
{
  public void Configure(EntityTypeBuilder<Sector> builder)
  {
    builder.HasData(
        new Sector() { Id = 1, Descripcion = "Barra de tragos y vinos" },
        new Sector() { Id = 2, Descripcion = "Barra de choperas de cerveza artesanal" },
        new Sector() { Id = 3, Descripcion = "Cocina" },
        new Sector() { Id = 4, Descripcion = "Candy Bar" }
    );
  }
}