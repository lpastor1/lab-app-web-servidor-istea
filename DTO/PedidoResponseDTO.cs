namespace lab_app_web_servidor_istea.DTO
{
  public class PedidoResponseDTO
  {
    public required int Cantidad { get; set; }
    public required DateTime FechaCreacion { get; set; }
    public required DateTime FechaFinalizacion { get; set; }
    public required string Producto { get; set; }
    public required int ProductoId { get; set; }
    public required int Id { get; set; }
    public required string Mesa { get; set; }
    public required string NombreCliente { get; set; }
    public required string EstadosPedido { get; set; }
  }
}
