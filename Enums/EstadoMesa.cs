using System.ComponentModel;

namespace lab_app_web_servidor_istea.Enums
{
  public enum EstadoMesaEnum
  {

    [Description("Cliente esperando pedido")]
    ClienteEsperandoPedido,
    [Description("Cliente comiendo")]
    ClienteComiendo,
    [Description("Cliente pagando")]
    ClientePagando,
    [Description("Mesa cerrada")]
    Cerrada
  }
}
