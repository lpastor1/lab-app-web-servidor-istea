using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab_app_web_servidor_istea.Entities;

public class Empleado : EntityWithId
{
  [Required] public required string Nombre { get; set; }

  [Required] public required string Usuario { get; set; }

  [Required] public required string Password { get; set; }
  [ForeignKey(nameof(Sector))] public int IdSector { get; set; }

  [ForeignKey(nameof(Rol))] public int RoleId { get; set; }

  public virtual Sector Sector { get; set; } = null!;

  public virtual Rol Rol { get; set; } = null!;
}