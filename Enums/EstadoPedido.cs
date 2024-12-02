using System.ComponentModel;

namespace lab_app_web_servidor_istea.Enums
{
  public enum EstadoPedido
  {
    [Description("Pendiente")]
    Pendiente = 1,
    [Description("En preparación")]
    EnPreparacion = 2,
    [Description("Listo para servir")]
    ListoParaServir = 3
  }
}
