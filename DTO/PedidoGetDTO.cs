namespace lab_app_web_servidor_istea.DTO
{
  public class PedidoGetDTO
  {
    public int IdComanda { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public int IdEstado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaFinalizacion { get; set; }
  }
}
