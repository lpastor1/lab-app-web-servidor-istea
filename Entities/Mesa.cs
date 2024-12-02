using System.ComponentModel.DataAnnotations.Schema;

namespace lab_app_web_servidor_istea.Entities;

public class Mesa : EntityWithId
{
  public required string Nombre { get; set; }

  [ForeignKey(nameof(EstadosMesa))] public int EstadosMesaId { get; set; }

  public EstadosMesa EstadosMesa { get; set; } = null!;
}