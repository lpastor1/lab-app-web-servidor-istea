using lab_app_web_servidor_istea.Enums;
using lab_app_web_servidor_istea.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lab_app_web_servidor_istea.Database.DataSeed;

public class RolesSeed : IEntityTypeConfiguration<Rol>
{
  public void Configure(EntityTypeBuilder<Rol> builder)
  {
    builder.HasData(
        new Rol() { Id = 1, Descripcion = RolTrabajador.Bartender.ToString() },
        new Rol() { Id = 2, Descripcion = RolTrabajador.Cervecero.ToString() },
        new Rol() { Id = 3, Descripcion = RolTrabajador.Cocinero.ToString() },
        new Rol() { Id = 4, Descripcion = RolTrabajador.Mozo.ToString() },
        new Rol() { Id = 5, Descripcion = RolTrabajador.Socio.ToString() }
    );
  }
}