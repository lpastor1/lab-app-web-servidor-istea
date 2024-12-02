namespace lab_app_web_servidor_istea.DTO
{
  public class ComandaResponseDTO
  {
    public string NombreCliente { get; set; }
    public string NombreMesa { get; set; }
    public List<PedidoResponseDTO> Pedidos { get; set; }
  }
}
