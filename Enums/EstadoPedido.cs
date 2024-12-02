using System.ComponentModel;

namespace lab_app_web_servidor_istea.Enums
{
  public enum EstadoPedido
  {
    [Description("Pendiente")]
    Pendiente,
    [Description("En preparación")]
    EnPreparacion,
    [Description("Listo para servir")]
    ListoParaServir
  }
}
