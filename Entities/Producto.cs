using System.ComponentModel.DataAnnotations.Schema;

namespace lab_app_web_servidor_istea.Entities;

public class Producto : EntityWithId
{
  [ForeignKey(nameof(Sector))] public int SectorId { get; set; }

  public required string Descripcion { get; set; }

  public int Stock { get; set; }

  public decimal Precio { get; set; }

  public virtual ICollection<Pedido> Pedidos { get; set; } = [];

  public virtual required Sector Sector { get; set; }

  public void ReducirStock(int cantidad)
  {
    int nuevoStock = Stock - cantidad;
    if (nuevoStock < 0)
    {
      throw new Exception($"No se puede reducir el stock en {cantidad} ya que el stock actual ts {Stock}");
    }

    Stock = nuevoStock;
  }

  public override string ToString()
  {
    return Descripcion;
  }
}