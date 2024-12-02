using System.ComponentModel.DataAnnotations.Schema;

namespace lab_app_web_servidor_istea.Entities;

public class Comanda : EntityWithId
{
  [ForeignKey(nameof(Mesa))] public int MesaId { get; set; }

  public string NombreCliente { get; set; } = null!;

  public virtual Mesa Mesa { get; set; } = null!;

  public virtual ICollection<Pedido> Pedidos { get; set; } = [];
}