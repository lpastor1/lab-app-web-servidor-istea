using lab_app_web_servidor_istea.Enums;
using lab_app_web_servidor_istea.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lab_app_web_servidor_istea.Database.DataSeed;

public class EstadosMesaSeed : IEntityTypeConfiguration<EstadosMesa>
{
  public void Configure(EntityTypeBuilder<EstadosMesa> builder)
  {
    builder.HasData(
        new EstadosMesa() { Id = 1, Descripcion = EstadoMesa.ClienteEsperandoPedido.ToString() },
        new EstadosMesa() { Id = 2, Descripcion = EstadoMesa.ClienteComiendo.ToString() },
        new EstadosMesa() { Id = 3, Descripcion = EstadoMesa.ClientePagando.ToString() },
        new EstadosMesa() { Id = 4, Descripcion = EstadoMesa.Cerrada.ToString() }
    );
  }
}