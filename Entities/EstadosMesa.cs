namespace lab_app_web_servidor_istea.Entities;

public class EstadosMesa : EntityWithId
{
  public required string Descripcion { get; set; }

  public virtual ICollection<Mesa> Mesas { get; set; } = [];
}