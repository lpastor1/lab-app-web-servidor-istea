using System.ComponentModel.DataAnnotations.Schema;

namespace lab_app_web_servidor_istea.Entities
{
  public class RegistroEmpleado : EntityWithId
  {
    [ForeignKey(nameof(Empleado))] public int IdEmpleado { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;

    public DateTime FechaHora { get; set; }
  }
}
