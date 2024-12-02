using System.ComponentModel;

namespace lab_app_web_servidor_istea.Enums;

public enum RolTrabajador
{
  [Description("Bartender")]
  Bartender,
  [Description("Cervecero")]
  Cervecero,
  [Description("Cocinero")]
  Cocinero,
  [Description("Mozo")]
  Mozo,
  [Description("Socio")]
  Socio
}