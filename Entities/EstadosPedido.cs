namespace lab_app_web_servidor_istea.Entities;

public class EstadosPedido : EntityWithId
{
  public string Descripcion { get; set; } = null!;

  public virtual ICollection<Pedido> Pedidos { get; set; } = [];
}