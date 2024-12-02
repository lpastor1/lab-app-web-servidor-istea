using lab_app_web_servidor_istea.Enums;
using lab_app_web_servidor_istea.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lab_app_web_servidor_istea.Database.DataSeed;

public class EstadosPedidosSeed : IEntityTypeConfiguration<EstadosPedido>
{
  public void Configure(EntityTypeBuilder<EstadosPedido> builder)
  {
    builder.HasData(
        new EstadosPedido() { Id = 1, Descripcion = EstadoPedido.Pendiente.ToString() },
        new EstadosPedido() { Id = 2, Descripcion = EstadoPedido.EnPreparacion.ToString() },
        new EstadosPedido() { Id = 3, Descripcion = EstadoPedido.ListoParaServir.ToString() }
    );
  }
}