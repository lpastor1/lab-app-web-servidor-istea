using System.ComponentModel;

namespace lab_app_web_servidor_istea.Enums
{
  public enum EstadoMesa
  {

    [Description("Cliente esperando pedido")]
    ClienteEsperandoPedido = 1,
    [Description("Cliente comiendo")]
    ClienteComiendo = 2,
    [Description("Cliente pagando")]
    ClientePagando= 3,
    [Description("Mesa cerrada")]
    Cerrada = 4
  }
}
