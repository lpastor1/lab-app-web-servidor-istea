using lab_app_web_servidor_istea.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lab_app_web_servidor_istea.Database.DataSeed;

public class EmpleadoSeed : IEntityTypeConfiguration<Empleado>
{
  public void Configure(EntityTypeBuilder<Empleado> builder)
  {
    builder.HasData(
        new Empleado() { Id = 1, RolId = 0, Nombre = "Enzo Francescoli", Password = "river1", IdSector = 0, Usuario = "elenzo" },
        new Empleado() { Id = 2, RolId = 1, Nombre = "Angel Labruna", Password = "river2", IdSector = 1, Usuario = "angelito" },
        new Empleado() { Id = 3, RolId = 2, Nombre = "Marcelo Gallardo", Password = "river3", IdSector = 2, Usuario = "elmunie" },
        new Empleado() { Id = 4, RolId = 3, Nombre = "Norberto Alonso", Password = "river4", IdSector = 3, Usuario = "elbeto" },
        new Empleado() { Id = 5, RolId = 4, Nombre = "Amadeo Carrizo", Password = "river5", IdSector = 3, Usuario = "elpulpo" }
    );
  }
}