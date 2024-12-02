using lab_app_web_servidor_istea.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lab_app_web_servidor_istea.Database.DataSeed;

public class ProductosSeed : IEntityTypeConfiguration<Producto>
{
  public void Configure(EntityTypeBuilder<Producto> builder)
  {
    builder.HasData(
        new Producto() { Id = 1, Descripcion = "Hamburguesa Clasica", Stock = 100, SectorId = 3, Precio = 8000 },
        new Producto() { Id = 2, Descripcion = "Hamburguesa Completa", Stock = 200, SectorId = 3, Precio = 10000 },
        new Producto() { Id = 3, Descripcion = "Hamburguesa con Hongos", Stock = 300, SectorId = 3, Precio = 12000 },
        new Producto() { Id = 4, Descripcion = "Hamburguesa Doble Carne Doble Queso", Stock = 300, SectorId = 3, Precio = 12000 },
        new Producto() { Id = 5, Descripcion = "Hamburguesa BBQ", Stock = 100, SectorId = 3, Precio = 12000 },
        new Producto() { Id = 6, Descripcion = "Hamburguesa Vegetariana", Stock = 500, SectorId = 3, Precio = 9000 },

        new Producto() { Id = 7, Descripcion = "Nonthue Kolsch", Stock = 10, SectorId = 2, Precio = 4500 },
        new Producto() { Id = 8, Descripcion = "Nonthue Bitter", Stock = 20, SectorId = 2, Precio = 4500 },
        new Producto() { Id = 9, Descripcion = "Nonthue Ipa", Stock = 15, SectorId = 2, Precio = 4500 },
        new Producto() { Id = 10, Descripcion = "Nonthue Porter", Stock = 10, SectorId = 2, Precio = 4500 },
        new Producto() { Id = 11, Descripcion = "Patagonia Session IPA", Stock = 15, SectorId = 2, Precio = 6000 },
        new Producto() { Id = 12, Descripcion = "Patagonia Vera IPA", Stock = 20, SectorId = 2, Precio = 6000 },

        new Producto() { Id = 13, Descripcion = "La Vaquita Santa Julia", Stock = 5, SectorId = 1, Precio = 16000 },
        new Producto() { Id = 14, Descripcion = "El Zorrito Santa Julia", Stock = 5, SectorId = 1, Precio = 16000 },

        new Producto() { Id = 15, Descripcion = "Bizcocho de Chocolate", Stock = 5, SectorId = 4, Precio = 6000 },
        new Producto() { Id = 16, Descripcion = "Bizcocho de Vainilla", Stock = 5, SectorId = 4, Precio = 6000 }
    );
  }
}